using Microsoft.VisualBasic.ApplicationServices;
using System.Windows.Forms;
using System;
using System.Diagnostics;
using System.ServiceProcess;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Drawing.Drawing2D;
using System.Media;


namespace PrimerProgama
{

    public partial class FastEthernet : Form
    {
        public FastEthernet()
        {
            InitializeComponent();


            // Asegúrate de que este código se ejecute después de la inicialización de pictureBox1 y tituloPrograma
            tituloPrograma.Parent = pictureBox1; // Establece el PictureBox como el padre del Label
            tituloPrograma.BackColor = Color.Transparent; // Asegura que el fondo del Label sea transparente
            LabelCopyright.Parent = pictureBox1;
            LabelCopyright.BackColor = Color.Transparent;
            loadGif.Parent = pictureBox1;
            loadGif.BackColor = Color.Transparent;


            var assembly = Assembly.GetExecutingAssembly();

            // Asegúrate de que este nombre coincida exactamente con lo que mostró el MessageBox
            string resourceName = "PrimerProgama.Resources.cursorAnimado.ani";

            // Crea una ruta temporal para el archivo del cursor
            string tempFilePath = Path.GetTempPath() + "cursorAnimado.ani";

            using (Stream resourceStream = assembly.GetManifestResourceStream(resourceName))
            {
                if (resourceStream != null)
                {
                    using (var fileStream = File.Create(tempFilePath))
                    {
                        resourceStream.CopyTo(fileStream);
                    }
                }
                else
                {
                    MessageBox.Show("El recurso del cursor no se pudo encontrar.");
                    return;
                }
            }

            // Carga el cursor animado desde el archivo temporal
            IntPtr cursorHandle = NativeMethods.LoadCursorFromFile(tempFilePath);
            if (cursorHandle != IntPtr.Zero)
            {
                // Establece el cursor animado para el formulario
                this.Cursor = new Cursor(cursorHandle);
            }
            else
            {
                MessageBox.Show("No se pudo cargar el cursor animado.");
            }

            // Opcional: Eliminar el archivo temporal al cerrar la aplicación
            this.FormClosed += (sender, e) => File.Delete(tempFilePath);


            // Asegúrate de ajustar el radio según necesites
            int cornerRadius = 20;

            ConfigurarBoton(cambiarDNS, cornerRadius);
            ConfigurarBoton(limpiaCarpetaTemp, cornerRadius);
            ConfigurarBoton(limpiaCarpetaTemp2, cornerRadius);
            ConfigurarBoton(memoriaCache, cornerRadius);
            ConfigurarBoton(desactivarServiciosActu, cornerRadius);

        }


        private async void memoriaCache_Click(object sender, EventArgs e)
        {
            // Reproduce el sonido de clic aquí
            reproducirSonidoClik();


           // Muestra el GIF de carga
             loadGif.Visible = true;


            // Ejecuta el proceso en un hilo diferente para no bloquear la UI
            await Task.Run(() =>
            {
                var startInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/C ipconfig /flushdns",
                    UseShellExecute = false, // Es necesario para redireccionar la salida
                    RedirectStandardOutput = true, // Redirecciona la salida estándar
                    RedirectStandardError = true, // Redirecciona los errores
                    CreateNoWindow = true, // No crea una ventana de consola
                    Verb = "runas" // Ejecuta como administrador
                };

                try
                {
                    using (var process = System.Diagnostics.Process.Start(startInfo))
                    {
                        // Lee la salida del comando
                        string output = process.StandardOutput.ReadToEnd();
                        string error = process.StandardError.ReadToEnd();

                        // Espera a que el comando termine
                        process.WaitForExit();

                        // Muestra la salida o el error
                        // Utiliza BeginInvoke para actualizar la UI desde el hilo de la tarea
                        this.BeginInvoke(new Action(() =>
                        {
                            // Oculta el GIF de carga
                            loadGif.Visible = false;

                            if (!string.IsNullOrEmpty(output))
                            {
                                MessageBox.Show($"Resultado: {output}", "Exitó", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else if (!string.IsNullOrEmpty(error))
                            {

                                MessageBox.Show($"Error: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show("El comando se ejecutó, pero no hubo salida.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }));
                    }
                }
                catch (System.ComponentModel.Win32Exception)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        MessageBox.Show("Operación cancelada por el usuario o error al solicitar permisos de administrador.");
                    }));
                }
                catch (Exception ex)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        MessageBox.Show($"Error al ejecutar el comando: {ex.Message}");
                    }));
                }
            });
        }



        private async void limpiaCarpetaTemp_Click(object sender, EventArgs e)
        {
            // Reproduce el sonido de clic aquí
            reproducirSonidoClik();

            // Muestra el GIF de carga
            loadGif.Visible = true;

            string folderPath = @"C:\Windows\Temp";

            bool procesoExitoso = true;
            string mensajeError = string.Empty;

            await Task.Run(() =>
            {
                try
                {
                    // Elimina todos los archivos en la carpeta Temp
                    foreach (string file in Directory.GetFiles(folderPath))
                    {
                        try
                        {
                            File.Delete(file);
                        }
                        catch (IOException)
                        {
                            // El archivo está en uso o bloqueado, se omite
                            continue;
                        }
                        catch (UnauthorizedAccessException)
                        {
                            // No hay permisos suficientes para eliminar el archivo, se omite
                            continue;
                        }
                    }

                    // Elimina todas las subcarpetas y su contenido en la carpeta Temp
                    foreach (string dir in Directory.GetDirectories(folderPath))
                    {
                        try
                        {
                            Directory.Delete(dir, true); // true para eliminar subcarpetas y archivos
                        }
                        catch (IOException)
                        {
                            // La carpeta está en uso o bloqueada, se omite
                            continue;
                        }
                        catch (UnauthorizedAccessException)
                        {
                            // No hay permisos suficientes para eliminar la carpeta, se omite
                            continue;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Si ocurre un error durante el proceso general de eliminación
                    procesoExitoso = false;
                    mensajeError = ex.Message;
                }
            });

            // Oculta el GIF de carga
            loadGif.Visible = false;

            // Muestra el mensaje según el resultado de la limpieza
            if (procesoExitoso)
            {
                MessageBox.Show("La carpeta Temp ha sido limpiada correctamente.", "Limpieza completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Error al limpiar la carpeta Temp: {mensajeError}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void limpiaCarpetaTemp2_Click(object sender, EventArgs e)
        {
            // Reproduce el sonido de clic aquí
            reproducirSonidoClik();

            loadGif.Visible = true;

            bool procesoExitoso = true;

            string mensajeError = string.Empty;

            // Resuelve la ruta de la carpeta Temp del usuario actual
            string folderPath = Environment.GetEnvironmentVariable("TEMP");

            await Task.Run(() => 
            {

            try
            {
                // Elimina todos los archivos en la carpeta Temp
                foreach (string file in Directory.GetFiles(folderPath))
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch (IOException)
                    {
                        // El archivo está en uso o bloqueado, se omite
                        continue;
                    }
                    catch (UnauthorizedAccessException)
                    {
                        // No hay permisos suficientes para eliminar el archivo, se omite
                        continue;
                    }
                }
                // Elimina todas las subcarpetas y su contenido en la carpeta Temp
                foreach (string dir in Directory.GetFiles(folderPath))
                {
                    try
                    {
                        Directory.Delete(dir, true);// true para eliminar subcarpetas y archivos
                    }
                    catch (IOException)
                    {
                        continue;
                    }
                    catch (UnauthorizedAccessException)
                    {
                        continue;

                    }
                }

            }
            catch (Exception ex)
            {
                // Si ocurre un error durante el proceso general de eliminación
                MessageBox.Show($"Error al limpiar la carpeta temp: {ex.Message}");

            }
            });

            // Oculta el GIF de carga
            loadGif.Visible = false;

            // Muestra el mensaje según el resultado de la limpieza
            if (procesoExitoso)
            {
                MessageBox.Show("La carpeta Temp ha sido limpiada correctamente.", "Limpieza completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Error al limpiar la carpeta Temp: {mensajeError}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void desactivarServiciosActu_Click(object sender, EventArgs e)
        {
            // Reproduce el sonido de clic aquí
            reproducirSonidoClik();

            loadGif.Visible = true;

            bool ProcesoExitoso = true;

            string mensajeError = string.Empty;

            await Task.Run(() =>
            {

                try
                {
                    ServiceController sc = new ServiceController("wuauserv");

                    // Detiene el servicio si está en ejecución
                    if (sc.Status == ServiceControllerStatus.Running)
                    {
                        sc.Stop();
                        sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(40)); // Espera hasta 40 segundos para que el servicio se detenga
                    }

                    // Cambia el tipo de inicio del servicio a Deshabilitado
                    // Para esto, se necesita utilizar una llamada a 'sc.exe', ya que ServiceController no expone directamente una forma de cambiar el tipo de inicio
                    System.Diagnostics.Process.Start("sc.exe", "config wuauserv start= disabled");

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al desactivar el servicio de actualizaciones de Windows: {ex.Message}");
                }
            });
            loadGif.Visible = false;

            if (ProcesoExitoso)
            {
                MessageBox.Show("La carpeta %Temp% ha sido limpiada correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information );
            }
            else
            {
                MessageBox.Show($"Error al limpiar la carpeta Temp: {mensajeError}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void cambiarDNS_Click(object sender, EventArgs e)
        {
            // Reproduce el sonido de clic aquí
            reproducirSonidoClik();

            loadGif.Visible = true;

            bool procesoExitoso = true;
            string mensajeError = string.Empty;

            // Nombres de las interfaces a actualizar
            string[] interfaceNames = new string[] { "Wi-Fi", "Ethernet" }; // Asegúrate de que estos nombres coincidan con los de tus interfaces

            // Direcciones DNS de Google
            string primaryDNS = "8.8.8.8";
            string secondaryDNS = "8.8.4.4";

            await Task.Run(() =>
            {
                foreach (var interfaceName in interfaceNames)
                {
                    // Ejecuta el comando para establecer el DNS primario
                    var processPrimaryDNS = ExecuteNetshCommandAndWait($"interface ipv4 set dns name=\"{interfaceName}\" static {primaryDNS} primary");

                    if (processPrimaryDNS != null)
                    {
                        // Verifica si hubo algún error al establecer el DNS primario
                        string error = processPrimaryDNS.StandardError.ReadToEnd();
                        if (!string.IsNullOrEmpty(error))
                        {
                            procesoExitoso = false;
                            mensajeError = $"Error al establecer DNS primario en {interfaceName}: {error}";
                            break; // Sale del ciclo si hay un error
                        }

                        // Ejecuta el comando para agregar el DNS secundario
                        var processSecondaryDNS = ExecuteNetshCommandAndWait($"interface ipv4 add dns name=\"{interfaceName}\" addr={secondaryDNS} index=2");

                        // Verifica si hubo algún error al agregar el DNS secundario
                        error = processSecondaryDNS.StandardError.ReadToEnd();
                        if (!string.IsNullOrEmpty(error))
                        {
                            procesoExitoso = false;
                            mensajeError = $"Error al agregar DNS secundario en {interfaceName}: {error}";
                            break; // Sale del ciclo si hay un error
                        }
                    }
                    else
                    {
                        procesoExitoso = false;
                        mensajeError = "No se pudo ejecutar el comando netsh.";
                        break; // Sale del ciclo si hay un error
                    }
                }
            });

            loadGif.Visible = false;

            if (procesoExitoso)
            {
                MessageBox.Show("La configuración de DNS ha sido actualizada a Google DNS para todas las interfaces seleccionadas.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Error al actualizar DNS: {mensajeError}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private Process ExecuteNetshCommandAndWait(string arguments)
        {
            var processStartInfo = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "netsh",
                Arguments = arguments,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            var process = System.Diagnostics.Process.Start(processStartInfo);
            process.WaitForExit(); // Espera a que el comando se complete

            return process;
        }

        // Declaraciones de la API de Windows para trabajar con cursores
        public class NativeMethods
        {
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            public static extern IntPtr LoadCursorFromFile(string path);

            [DllImport("user32.dll")]
            public static extern IntPtr SetCursor(IntPtr hCursor);
        }

        private GraphicsPath GetRoundPath(RectangleF Rect, int radius)
        {
            float r2 = radius / 2f;
            GraphicsPath GraphPath = new GraphicsPath();

            GraphPath.AddArc(Rect.X, Rect.Y, radius, radius, 180, 90);
            GraphPath.AddLine(Rect.X + r2, Rect.Y, Rect.Width - r2, Rect.Y);
            GraphPath.AddArc(Rect.X + Rect.Width - radius, Rect.Y, radius, radius, 270, 90);
            GraphPath.AddLine(Rect.Width, Rect.Y + r2, Rect.Width, Rect.Height - r2);
            GraphPath.AddArc(Rect.X + Rect.Width - radius,
                             Rect.Y + Rect.Height - radius, radius, radius, 0, 90);
            GraphPath.AddLine(Rect.Width - r2, Rect.Height, Rect.X + r2, Rect.Height);
            GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - radius, radius, radius, 90, 90);
            GraphPath.AddLine(Rect.X, Rect.Height - r2, Rect.X, Rect.Y + r2);

            GraphPath.CloseFigure();
            return GraphPath;
        }

        private void ConfigurarBoton(Button btn, int cornerRadius)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.Blue;
            btn.ForeColor = Color.White;

            Color colorOriginal = btn.BackColor;

            // Efecto hover
            btn.MouseEnter += (sender, e) =>
            {
                colorOriginal = btn.BackColor;
                btn.BackColor = Color.Blue;
                reproducirSonidoOver();
            };

            btn.MouseEnter += (sender, e) =>
            {
                btn.BackColor = colorOriginal;
            };

            // Evento Paint para redondear esquinas
            btn.Paint += (sender, e) =>
            {
                RectangleF Rect = new RectangleF(0, 0, btn.Width, btn.Height);
                GraphicsPath GraphPath = GetRoundPath(Rect, cornerRadius);
                btn.Region = new Region(GraphPath);

                using (Pen pen = new Pen(Color.Transparent, 1.75f))
                {
                    pen.Alignment = PenAlignment.Inset;
                    e.Graphics.DrawPath(pen, GraphPath);
                }
            };

            // Evento Resize para mantener las esquinas redondeadas
            btn.Resize += (sender, e) =>
            {
                RectangleF Rect = new RectangleF(0, 0, btn.Width, btn.Height);
                GraphicsPath GraphPath = GetRoundPath(Rect, cornerRadius);
                btn.Region = new Region(GraphPath);
            };

            btn.Click += boton_click;
        }

        private void boton_click(object sender, EventArgs e)
        {
            reproducirSonidoClik();
        }

        private void reproducirSonidoClik()
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.sonidoClick);
            player.Play();
        }

        private void reproducirSonidoOver()
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.efectoOver);
            player.Play();
        }
    }
}
