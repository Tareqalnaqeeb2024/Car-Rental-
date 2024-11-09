
namespace CarRental.Booking
{
    partial class frmShowBookingInfo
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
            this.ctrlBookingCard1 = new CarRental.Booking.ctrlBookingCard();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(344, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Show Booking Info";
            // 
            // ctrlBookingCard1
            // 
            this.ctrlBookingCard1.BackColor = System.Drawing.Color.White;
            this.ctrlBookingCard1.Location = new System.Drawing.Point(31, 116);
            this.ctrlBookingCard1.Name = "ctrlBookingCard1";
            this.ctrlBookingCard1.Size = new System.Drawing.Size(807, 465);
            this.ctrlBookingCard1.TabIndex = 0;
            // 
            // frmShowBookingInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(850, 593);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlBookingCard1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "frmShowBookingInfo";
            this.Text = "frmShowBookingInfo";
            this.Load += new System.EventHandler(this.frmShowBookingInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlBookingCard ctrlBookingCard1;
        private System.Windows.Forms.Label label1;
    }
}