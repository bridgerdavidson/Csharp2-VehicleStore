namespace VehicleStoreGUIApp
{
    partial class FrmVehicleStore
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            rdoCar = new RadioButton();
            rdoMotorcycle = new RadioButton();
            rdoPickup = new RadioButton();
            rdoVehicle = new RadioButton();
            btnCreate = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnCreate);
            groupBox1.Controls.Add(rdoVehicle);
            groupBox1.Controls.Add(rdoPickup);
            groupBox1.Controls.Add(rdoMotorcycle);
            groupBox1.Controls.Add(rdoCar);
            groupBox1.Location = new Point(12, 21);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(305, 560);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Create a Vehicle";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // rdoCar
            // 
            rdoCar.AutoSize = true;
            rdoCar.Location = new Point(6, 26);
            rdoCar.Name = "rdoCar";
            rdoCar.Size = new Size(52, 24);
            rdoCar.TabIndex = 0;
            rdoCar.TabStop = true;
            rdoCar.Text = "Car";
            rdoCar.UseVisualStyleBackColor = true;
            // 
            // rdoMotorcycle
            // 
            rdoMotorcycle.AutoSize = true;
            rdoMotorcycle.Location = new Point(158, 26);
            rdoMotorcycle.Name = "rdoMotorcycle";
            rdoMotorcycle.Size = new Size(104, 24);
            rdoMotorcycle.TabIndex = 1;
            rdoMotorcycle.TabStop = true;
            rdoMotorcycle.Text = "Motorcycle";
            rdoMotorcycle.UseVisualStyleBackColor = true;
            // 
            // rdoPickup
            // 
            rdoPickup.AutoSize = true;
            rdoPickup.Location = new Point(6, 75);
            rdoPickup.Name = "rdoPickup";
            rdoPickup.Size = new Size(73, 24);
            rdoPickup.TabIndex = 2;
            rdoPickup.TabStop = true;
            rdoPickup.Text = "Pickup";
            rdoPickup.UseVisualStyleBackColor = true;
            // 
            // rdoVehicle
            // 
            rdoVehicle.AutoSize = true;
            rdoVehicle.Location = new Point(158, 75);
            rdoVehicle.Name = "rdoVehicle";
            rdoVehicle.Size = new Size(77, 24);
            rdoVehicle.TabIndex = 3;
            rdoVehicle.TabStop = true;
            rdoVehicle.Text = "Vehicle";
            rdoVehicle.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(96, 507);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(94, 29);
            btnCreate.TabIndex = 4;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += BtnCreateClickEH;
            // 
            // FrmVehicleStore
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 671);
            Controls.Add(groupBox1);
            Name = "FrmVehicleStore";
            Text = "FrmVehicleStore";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private RadioButton rdoVehicle;
        private RadioButton rdoPickup;
        private RadioButton rdoMotorcycle;
        private RadioButton rdoCar;
        private Button btnCreate;
    }
}
