namespace GUI;

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
        itemsBox = new System.Windows.Forms.TextBox();
        seedBox = new System.Windows.Forms.TextBox();
        capacityBox = new System.Windows.Forms.TextBox();
        runButton = new System.Windows.Forms.Button();
        resultsBox = new System.Windows.Forms.TextBox();
        instanceBox = new System.Windows.Forms.TextBox();
        RESULTS = new System.Windows.Forms.Label();
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        label4 = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // itemsBox
        // 
        itemsBox.Location = new System.Drawing.Point(61, 21);
        itemsBox.Name = "itemsBox";
        itemsBox.Size = new System.Drawing.Size(100, 23);
        itemsBox.TabIndex = 0;
        // 
        // seedBox
        // 
        seedBox.Location = new System.Drawing.Point(61, 78);
        seedBox.Name = "seedBox";
        seedBox.Size = new System.Drawing.Size(100, 23);
        seedBox.TabIndex = 1;
        // 
        // capacityBox
        // 
        capacityBox.Location = new System.Drawing.Point(61, 135);
        capacityBox.Name = "capacityBox";
        capacityBox.Size = new System.Drawing.Size(100, 23);
        capacityBox.TabIndex = 2;
        // 
        // runButton
        // 
        runButton.BackColor = System.Drawing.SystemColors.ButtonFace;
        runButton.Cursor = System.Windows.Forms.Cursors.Hand;
        runButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
        runButton.Font = new System.Drawing.Font("Segoe UI", 14F);
        runButton.ForeColor = System.Drawing.Color.Crimson;
        runButton.Location = new System.Drawing.Point(12, 184);
        runButton.Name = "runButton";
        runButton.Size = new System.Drawing.Size(202, 42);
        runButton.TabIndex = 3;
        runButton.Text = "Odpalaj maszynke";
        runButton.UseVisualStyleBackColor = false;
        runButton.Click += runButton_Click;
        // 
        // resultsBox
        // 
        resultsBox.Cursor = System.Windows.Forms.Cursors.Arrow;
        resultsBox.Location = new System.Drawing.Point(12, 268);
        resultsBox.Multiline = true;
        resultsBox.Name = "resultsBox";
        resultsBox.ReadOnly = true;
        resultsBox.Size = new System.Drawing.Size(202, 170);
        resultsBox.TabIndex = 4;
        // 
        // instanceBox
        // 
        instanceBox.Cursor = System.Windows.Forms.Cursors.Arrow;
        instanceBox.Location = new System.Drawing.Point(231, 37);
        instanceBox.Multiline = true;
        instanceBox.Name = "instanceBox";
        instanceBox.ReadOnly = true;
        instanceBox.Size = new System.Drawing.Size(202, 401);
        instanceBox.TabIndex = 5;
        // 
        // RESULTS
        // 
        RESULTS.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        RESULTS.Location = new System.Drawing.Point(12, 242);
        RESULTS.Name = "RESULTS";
        RESULTS.Size = new System.Drawing.Size(149, 23);
        RESULTS.TabIndex = 6;
        RESULTS.Text = "STATUS PLECAKA";
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        label1.Location = new System.Drawing.Point(231, 11);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(117, 23);
        label1.TabIndex = 7;
        label1.Text = "PRZEDMIOTY";
        label1.Click += label1_Click;
        // 
        // label2
        // 
        label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        label2.Location = new System.Drawing.Point(41, 5);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(149, 13);
        label2.TabIndex = 8;
        label2.Text = "LICZBA PRZEDMIOTÓW";
        // 
        // label3
        // 
        label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        label3.Location = new System.Drawing.Point(51, 62);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(120, 13);
        label3.TabIndex = 9;
        label3.Text = "ZIARNO MIESZANIA";
        // 
        // label4
        // 
        label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        label4.Location = new System.Drawing.Point(51, 119);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(130, 13);
        label4.TabIndex = 10;
        label4.Text = "POJEMNOŚĆ PLECAKA";
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(440, 450);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(RESULTS);
        Controls.Add(instanceBox);
        Controls.Add(resultsBox);
        Controls.Add(runButton);
        Controls.Add(capacityBox);
        Controls.Add(seedBox);
        Controls.Add(itemsBox);
        Text = "PROBLEM PLECAKOWY";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label RESULTS;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;

    private System.Windows.Forms.TextBox instanceBox;

    private System.Windows.Forms.TextBox itemsBox;
    private System.Windows.Forms.TextBox seedBox;
    private System.Windows.Forms.TextBox capacityBox;
    private System.Windows.Forms.Button runButton;
    private System.Windows.Forms.TextBox resultsBox;

    #endregion
}