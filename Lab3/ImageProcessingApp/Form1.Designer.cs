namespace ImageProcessingApp;

partial class Form1
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        pictureBoxOrg = new System.Windows.Forms.PictureBox();
        pictureBoxNeg = new System.Windows.Forms.PictureBox();
        pictureBoxGray = new System.Windows.Forms.PictureBox();
        pictureBoxProg = new System.Windows.Forms.PictureBox();
        pictureBoxRed = new System.Windows.Forms.PictureBox();
        buttonProcessImage = new System.Windows.Forms.Button();
        buttonLoadImage = new System.Windows.Forms.Button();
        openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
        ((System.ComponentModel.ISupportInitialize)pictureBoxOrg).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxNeg).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxGray).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxProg).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxRed).BeginInit();
        SuspendLayout();
        // 
        // pictureBoxOrg
        // 
        pictureBoxOrg.Location = new System.Drawing.Point(30, 31);
        pictureBoxOrg.Name = "pictureBoxOrg";
        pictureBoxOrg.Size = new System.Drawing.Size(324, 316);
        pictureBoxOrg.TabIndex = 0;
        pictureBoxOrg.TabStop = false;
        // 
        // pictureBoxNeg
        // 
        pictureBoxNeg.Location = new System.Drawing.Point(403, 75);
        pictureBoxNeg.Name = "pictureBoxNeg";
        pictureBoxNeg.Size = new System.Drawing.Size(155, 144);
        pictureBoxNeg.TabIndex = 1;
        pictureBoxNeg.TabStop = false;
        // 
        // pictureBoxGray
        // 
        pictureBoxGray.Location = new System.Drawing.Point(403, 249);
        pictureBoxGray.Name = "pictureBoxGray";
        pictureBoxGray.Size = new System.Drawing.Size(155, 144);
        pictureBoxGray.TabIndex = 2;
        pictureBoxGray.TabStop = false;
        // 
        // pictureBoxProg
        // 
        pictureBoxProg.Location = new System.Drawing.Point(618, 75);
        pictureBoxProg.Name = "pictureBoxProg";
        pictureBoxProg.Size = new System.Drawing.Size(155, 144);
        pictureBoxProg.TabIndex = 3;
        pictureBoxProg.TabStop = false;
        // 
        // pictureBoxRed
        // 
        pictureBoxRed.Location = new System.Drawing.Point(618, 249);
        pictureBoxRed.Name = "pictureBoxRed";
        pictureBoxRed.Size = new System.Drawing.Size(155, 144);
        pictureBoxRed.TabIndex = 4;
        pictureBoxRed.TabStop = false;
        // 
        // buttonProcessImage
        // 
        buttonProcessImage.Location = new System.Drawing.Point(528, 12);
        buttonProcessImage.Name = "buttonProcessImage";
        buttonProcessImage.Size = new System.Drawing.Size(126, 38);
        buttonProcessImage.TabIndex = 5;
        buttonProcessImage.Text = "Process";
        buttonProcessImage.UseVisualStyleBackColor = true;
        buttonProcessImage.Click += buttonProcessImage_Click;
        // 
        // buttonLoadImage
        // 
        buttonLoadImage.Location = new System.Drawing.Point(124, 379);
        buttonLoadImage.Name = "buttonLoadImage";
        buttonLoadImage.Size = new System.Drawing.Size(126, 38);
        buttonLoadImage.TabIndex = 6;
        buttonLoadImage.Text = "Load image";
        buttonLoadImage.UseVisualStyleBackColor = true;
        buttonLoadImage.Click += buttonLoadImage_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(buttonLoadImage);
        Controls.Add(buttonProcessImage);
        Controls.Add(pictureBoxRed);
        Controls.Add(pictureBoxProg);
        Controls.Add(pictureBoxGray);
        Controls.Add(pictureBoxNeg);
        Controls.Add(pictureBoxOrg);
        Text = "Form1";
        ((System.ComponentModel.ISupportInitialize)pictureBoxOrg).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxNeg).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxGray).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxProg).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBoxRed).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.PictureBox pictureBoxOrg;
    private System.Windows.Forms.PictureBox pictureBoxNeg;
    private System.Windows.Forms.PictureBox pictureBoxGray;
    private System.Windows.Forms.PictureBox pictureBoxProg;
    private System.Windows.Forms.PictureBox pictureBoxRed;
    private System.Windows.Forms.Button buttonProcessImage;
    private System.Windows.Forms.Button buttonLoadImage;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;

    #endregion
}