namespace P520233_KeirynSandi.Formularios
{
    partial class FrmUsuariosGestion
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
            this.TxtBuscar = new System.Windows.Forms.TextBox();
            this.CbVerActivos = new System.Windows.Forms.CheckBox();
            this.DgListaUsuario = new System.Windows.Forms.DataGridView();
            this.ColUsuarioID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCorreo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CbUsuarioActivo = new System.Windows.Forms.CheckBox();
            this.TxtUsuarioDireccion = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtUsuarioTelefono = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.BtnVerContrsenia = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtUsuarioContrasenia = new System.Windows.Forms.TextBox();
            this.CboxUsuarioTipoRol = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtUsuarioCorreo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtUsuarioNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtUsuarioCedula = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtUsuarioCodigo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.BtnModificarUsuario = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnLimpiar = new System.Windows.Forms.Button();
            this.BtnCerrar = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgListaUsuario)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(472, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "BUSCAR";
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.Location = new System.Drawing.Point(541, 12);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(238, 22);
            this.TxtBuscar.TabIndex = 1;
            // 
            // CbVerActivos
            // 
            this.CbVerActivos.AutoSize = true;
            this.CbVerActivos.Checked = true;
            this.CbVerActivos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbVerActivos.Location = new System.Drawing.Point(932, 14);
            this.CbVerActivos.Name = "CbVerActivos";
            this.CbVerActivos.Size = new System.Drawing.Size(154, 20);
            this.CbVerActivos.TabIndex = 2;
            this.CbVerActivos.Text = "Ver Usuarios Activos";
            this.CbVerActivos.UseVisualStyleBackColor = true;
            // 
            // DgListaUsuario
            // 
            this.DgListaUsuario.AllowUserToAddRows = false;
            this.DgListaUsuario.AllowUserToDeleteRows = false;
            this.DgListaUsuario.AllowUserToOrderColumns = true;
            this.DgListaUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgListaUsuario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColUsuarioID,
            this.ColCedula,
            this.ColNombre,
            this.ColCorreo,
            this.ColTelefono,
            this.ColRol});
            this.DgListaUsuario.Location = new System.Drawing.Point(163, 73);
            this.DgListaUsuario.MultiSelect = false;
            this.DgListaUsuario.Name = "DgListaUsuario";
            this.DgListaUsuario.ReadOnly = true;
            this.DgListaUsuario.RowHeadersVisible = false;
            this.DgListaUsuario.RowHeadersWidth = 51;
            this.DgListaUsuario.RowTemplate.Height = 24;
            this.DgListaUsuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgListaUsuario.Size = new System.Drawing.Size(1077, 346);
            this.DgListaUsuario.TabIndex = 3;
            this.DgListaUsuario.VirtualMode = true;
            // 
            // ColUsuarioID
            // 
            this.ColUsuarioID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColUsuarioID.DataPropertyName = "UsuarioID";
            this.ColUsuarioID.HeaderText = "CÓDIGO ";
            this.ColUsuarioID.MinimumWidth = 6;
            this.ColUsuarioID.Name = "ColUsuarioID";
            this.ColUsuarioID.ReadOnly = true;
            this.ColUsuarioID.Width = 80;
            // 
            // ColCedula
            // 
            this.ColCedula.DataPropertyName = "Cedula";
            this.ColCedula.HeaderText = "CÉDULA";
            this.ColCedula.MinimumWidth = 6;
            this.ColCedula.Name = "ColCedula";
            this.ColCedula.ReadOnly = true;
            this.ColCedula.Width = 125;
            // 
            // ColNombre
            // 
            this.ColNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColNombre.DataPropertyName = "Nombre";
            this.ColNombre.HeaderText = "NOMBRE";
            this.ColNombre.MinimumWidth = 6;
            this.ColNombre.Name = "ColNombre";
            this.ColNombre.ReadOnly = true;
            // 
            // ColCorreo
            // 
            this.ColCorreo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColCorreo.DataPropertyName = "Correo";
            this.ColCorreo.HeaderText = "CORREO";
            this.ColCorreo.MinimumWidth = 6;
            this.ColCorreo.Name = "ColCorreo";
            this.ColCorreo.ReadOnly = true;
            this.ColCorreo.Width = 120;
            // 
            // ColTelefono
            // 
            this.ColTelefono.DataPropertyName = "Telefono";
            this.ColTelefono.HeaderText = "TELÉFONO";
            this.ColTelefono.MinimumWidth = 6;
            this.ColTelefono.Name = "ColTelefono";
            this.ColTelefono.ReadOnly = true;
            this.ColTelefono.Width = 125;
            // 
            // ColRol
            // 
            this.ColRol.DataPropertyName = "Rol";
            this.ColRol.HeaderText = "ROL DE USUARIO";
            this.ColRol.MinimumWidth = 6;
            this.ColRol.Name = "ColRol";
            this.ColRol.ReadOnly = true;
            this.ColRol.Width = 125;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.CbUsuarioActivo);
            this.groupBox1.Controls.Add(this.TxtUsuarioDireccion);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.TxtUsuarioTelefono);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.BtnVerContrsenia);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.TxtUsuarioContrasenia);
            this.groupBox1.Controls.Add(this.CboxUsuarioTipoRol);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.TxtUsuarioCorreo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.TxtUsuarioNombre);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TxtUsuarioCedula);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TxtUsuarioCodigo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(56, 442);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1341, 330);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalles del Usuario";
            // 
            // CbUsuarioActivo
            // 
            this.CbUsuarioActivo.AutoSize = true;
            this.CbUsuarioActivo.Enabled = false;
            this.CbUsuarioActivo.Location = new System.Drawing.Point(528, 36);
            this.CbUsuarioActivo.Name = "CbUsuarioActivo";
            this.CbUsuarioActivo.Size = new System.Drawing.Size(66, 20);
            this.CbUsuarioActivo.TabIndex = 17;
            this.CbUsuarioActivo.Text = "Activo";
            this.CbUsuarioActivo.UseVisualStyleBackColor = true;
            // 
            // TxtUsuarioDireccion
            // 
            this.TxtUsuarioDireccion.Location = new System.Drawing.Point(886, 140);
            this.TxtUsuarioDireccion.Multiline = true;
            this.TxtUsuarioDireccion.Name = "TxtUsuarioDireccion";
            this.TxtUsuarioDireccion.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtUsuarioDireccion.Size = new System.Drawing.Size(338, 133);
            this.TxtUsuarioDireccion.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1013, 121);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 15;
            this.label9.Text = "Dirección";
            // 
            // TxtUsuarioTelefono
            // 
            this.TxtUsuarioTelefono.Location = new System.Drawing.Point(138, 276);
            this.TxtUsuarioTelefono.Name = "TxtUsuarioTelefono";
            this.TxtUsuarioTelefono.Size = new System.Drawing.Size(357, 22);
            this.TxtUsuarioTelefono.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(283, 257);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 16);
            this.label8.TabIndex = 13;
            this.label8.Text = "Télefono";
            // 
            // BtnVerContrsenia
            // 
            this.BtnVerContrsenia.BackColor = System.Drawing.Color.Snow;
            this.BtnVerContrsenia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnVerContrsenia.Location = new System.Drawing.Point(1158, 91);
            this.BtnVerContrsenia.Name = "BtnVerContrsenia";
            this.BtnVerContrsenia.Size = new System.Drawing.Size(50, 27);
            this.BtnVerContrsenia.TabIndex = 12;
            this.BtnVerContrsenia.Text = "Ver";
            this.BtnVerContrsenia.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1001, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "Contraseña";
            // 
            // TxtUsuarioContrasenia
            // 
            this.TxtUsuarioContrasenia.Location = new System.Drawing.Point(886, 96);
            this.TxtUsuarioContrasenia.Name = "TxtUsuarioContrasenia";
            this.TxtUsuarioContrasenia.Size = new System.Drawing.Size(266, 22);
            this.TxtUsuarioContrasenia.TabIndex = 10;
            // 
            // CboxUsuarioTipoRol
            // 
            this.CboxUsuarioTipoRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboxUsuarioTipoRol.FormattingEnabled = true;
            this.CboxUsuarioTipoRol.Location = new System.Drawing.Point(886, 32);
            this.CboxUsuarioTipoRol.Name = "CboxUsuarioTipoRol";
            this.CboxUsuarioTipoRol.Size = new System.Drawing.Size(300, 24);
            this.CboxUsuarioTipoRol.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(992, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Tipo Usuario";
            // 
            // TxtUsuarioCorreo
            // 
            this.TxtUsuarioCorreo.Location = new System.Drawing.Point(138, 216);
            this.TxtUsuarioCorreo.Name = "TxtUsuarioCorreo";
            this.TxtUsuarioCorreo.Size = new System.Drawing.Size(357, 22);
            this.TxtUsuarioCorreo.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(260, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Correo electrónico";
            // 
            // TxtUsuarioNombre
            // 
            this.TxtUsuarioNombre.Location = new System.Drawing.Point(138, 157);
            this.TxtUsuarioNombre.Name = "TxtUsuarioNombre";
            this.TxtUsuarioNombre.Size = new System.Drawing.Size(357, 22);
            this.TxtUsuarioNombre.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(288, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Nombre";
            // 
            // TxtUsuarioCedula
            // 
            this.TxtUsuarioCedula.Location = new System.Drawing.Point(138, 98);
            this.TxtUsuarioCedula.Name = "TxtUsuarioCedula";
            this.TxtUsuarioCedula.Size = new System.Drawing.Size(357, 22);
            this.TxtUsuarioCedula.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(294, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cédula";
            // 
            // TxtUsuarioCodigo
            // 
            this.TxtUsuarioCodigo.Enabled = false;
            this.TxtUsuarioCodigo.Location = new System.Drawing.Point(138, 34);
            this.TxtUsuarioCodigo.Name = "TxtUsuarioCodigo";
            this.TxtUsuarioCodigo.Size = new System.Drawing.Size(357, 22);
            this.TxtUsuarioCodigo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(260, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Código de Usuario";
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.BackColor = System.Drawing.Color.DarkGreen;
            this.BtnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregar.ForeColor = System.Drawing.Color.White;
            this.BtnAgregar.Location = new System.Drawing.Point(319, 789);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(128, 32);
            this.BtnAgregar.TabIndex = 18;
            this.BtnAgregar.Text = "AGREGAR";
            this.BtnAgregar.UseVisualStyleBackColor = false;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // BtnModificarUsuario
            // 
            this.BtnModificarUsuario.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.BtnModificarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnModificarUsuario.ForeColor = System.Drawing.Color.White;
            this.BtnModificarUsuario.Location = new System.Drawing.Point(483, 789);
            this.BtnModificarUsuario.Name = "BtnModificarUsuario";
            this.BtnModificarUsuario.Size = new System.Drawing.Size(128, 32);
            this.BtnModificarUsuario.TabIndex = 19;
            this.BtnModificarUsuario.Text = "MODIFICAR";
            this.BtnModificarUsuario.UseVisualStyleBackColor = false;
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.BackColor = System.Drawing.Color.Maroon;
            this.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEliminar.ForeColor = System.Drawing.Color.White;
            this.BtnEliminar.Location = new System.Drawing.Point(642, 789);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(128, 32);
            this.BtnEliminar.TabIndex = 20;
            this.BtnEliminar.Text = "ELIMINAR";
            this.BtnEliminar.UseVisualStyleBackColor = false;
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLimpiar.ForeColor = System.Drawing.Color.White;
            this.BtnLimpiar.Location = new System.Drawing.Point(800, 789);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(128, 32);
            this.BtnLimpiar.TabIndex = 21;
            this.BtnLimpiar.Text = "LIMPIAR";
            this.BtnLimpiar.UseVisualStyleBackColor = false;
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.BackColor = System.Drawing.Color.Sienna;
            this.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCerrar.ForeColor = System.Drawing.Color.White;
            this.BtnCerrar.Location = new System.Drawing.Point(957, 789);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(128, 32);
            this.BtnCerrar.TabIndex = 22;
            this.BtnCerrar.Text = "CERRAR";
            this.BtnCerrar.UseVisualStyleBackColor = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("MS Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(350, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 18);
            this.label10.TabIndex = 18;
            this.label10.Text = "*";
        
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("MS Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(350, 136);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(18, 18);
            this.label11.TabIndex = 19;
            this.label11.Text = "*";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("MS Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(383, 195);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(18, 18);
            this.label12.TabIndex = 20;
            this.label12.Text = "*";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("MS Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(1083, 11);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(18, 18);
            this.label13.TabIndex = 24;
            this.label13.Text = "*";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("MS Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(1083, 65);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(18, 18);
            this.label14.TabIndex = 25;
            this.label14.Text = "*";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("MS Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(873, 280);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(18, 18);
            this.label15.TabIndex = 26;
            this.label15.Text = "*";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(897, 279);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(147, 16);
            this.label16.TabIndex = 27;
            this.label16.Text = "DATOS REQUERIDOS";
            // 
            // FrmUsuariosGestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1417, 846);
            this.Controls.Add(this.BtnCerrar);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnModificarUsuario);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DgListaUsuario);
            this.Controls.Add(this.CbVerActivos);
            this.Controls.Add(this.TxtBuscar);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmUsuariosGestion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Usuarios";
            this.Load += new System.EventHandler(this.FrmUsuariosGestion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgListaUsuario)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtBuscar;
        private System.Windows.Forms.CheckBox CbVerActivos;
        private System.Windows.Forms.DataGridView DgListaUsuario;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtUsuarioNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtUsuarioCedula;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtUsuarioCodigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CboxUsuarioTipoRol;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtUsuarioCorreo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtUsuarioContrasenia;
        private System.Windows.Forms.TextBox TxtUsuarioDireccion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtUsuarioTelefono;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button BtnVerContrsenia;
        private System.Windows.Forms.CheckBox CbUsuarioActivo;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.Button BtnModificarUsuario;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnLimpiar;
        private System.Windows.Forms.Button BtnCerrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUsuarioID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCedula;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCorreo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRol;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
    }
}