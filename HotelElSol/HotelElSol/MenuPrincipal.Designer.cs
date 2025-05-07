namespace HotelElSol
{
    partial class MenuPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnConsultaHabitaciones = new System.Windows.Forms.Button();
            this.btnRegistrarHabitaciones = new System.Windows.Forms.Button();
            this.btnSalidaHuesped = new System.Windows.Forms.Button();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(151, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bienvenido al Menu Principal.";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnConsultaHabitaciones
            // 
            this.btnConsultaHabitaciones.Location = new System.Drawing.Point(37, 65);
            this.btnConsultaHabitaciones.Name = "btnConsultaHabitaciones";
            this.btnConsultaHabitaciones.Size = new System.Drawing.Size(130, 23);
            this.btnConsultaHabitaciones.TabIndex = 1;
            this.btnConsultaHabitaciones.Text = "Consulta Habitaciones";
            this.btnConsultaHabitaciones.UseVisualStyleBackColor = true;
            this.btnConsultaHabitaciones.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRegistrarHabitaciones
            // 
            this.btnRegistrarHabitaciones.Location = new System.Drawing.Point(269, 65);
            this.btnRegistrarHabitaciones.Name = "btnRegistrarHabitaciones";
            this.btnRegistrarHabitaciones.Size = new System.Drawing.Size(138, 23);
            this.btnRegistrarHabitaciones.TabIndex = 2;
            this.btnRegistrarHabitaciones.Text = "Registrar Habitaciones";
            this.btnRegistrarHabitaciones.UseVisualStyleBackColor = true;
            this.btnRegistrarHabitaciones.Click += new System.EventHandler(this.btnRegistrarHabitaciones_Click);
            // 
            // btnSalidaHuesped
            // 
            this.btnSalidaHuesped.Location = new System.Drawing.Point(47, 132);
            this.btnSalidaHuesped.Name = "btnSalidaHuesped";
            this.btnSalidaHuesped.Size = new System.Drawing.Size(110, 23);
            this.btnSalidaHuesped.TabIndex = 3;
            this.btnSalidaHuesped.Text = "Salida Huesped";
            this.btnSalidaHuesped.UseVisualStyleBackColor = true;
            // 
            // btnFacturar
            // 
            this.btnFacturar.Location = new System.Drawing.Point(291, 121);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(75, 23);
            this.btnFacturar.TabIndex = 4;
            this.btnFacturar.Text = "Facturar";
            this.btnFacturar.UseVisualStyleBackColor = true;
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Location = new System.Drawing.Point(57, 197);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(75, 23);
            this.btnUsuarios.TabIndex = 5;
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(291, 197);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 261);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnUsuarios);
            this.Controls.Add(this.btnFacturar);
            this.Controls.Add(this.btnSalidaHuesped);
            this.Controls.Add(this.btnRegistrarHabitaciones);
            this.Controls.Add(this.btnConsultaHabitaciones);
            this.Controls.Add(this.label1);
            this.Name = "MenuPrincipal";
            this.Text = "MenuPrincipal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConsultaHabitaciones;
        private System.Windows.Forms.Button btnRegistrarHabitaciones;
        private System.Windows.Forms.Button btnSalidaHuesped;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnSalir;
    }
}