﻿namespace CaixeiroViajante
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtCidades = new System.Windows.Forms.TextBox();
            this.lblCidades = new System.Windows.Forms.Label();
            this.pnlCidades = new System.Windows.Forms.Panel();
            this.txtMaximo = new System.Windows.Forms.TextBox();
            this.btnGerar = new System.Windows.Forms.Button();
            this.pnlDistancias = new System.Windows.Forms.Panel();
            this.grdDistancias = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPopulacao = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtFitnessMinimo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlCidades.SuspendLayout();
            this.pnlDistancias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDistancias)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCidades
            // 
            this.txtCidades.Location = new System.Drawing.Point(6, 21);
            this.txtCidades.Name = "txtCidades";
            this.txtCidades.Size = new System.Drawing.Size(100, 20);
            this.txtCidades.TabIndex = 1;
            // 
            // lblCidades
            // 
            this.lblCidades.AutoSize = true;
            this.lblCidades.Location = new System.Drawing.Point(3, 5);
            this.lblCidades.Name = "lblCidades";
            this.lblCidades.Size = new System.Drawing.Size(45, 13);
            this.lblCidades.TabIndex = 0;
            this.lblCidades.Text = "Cidades";
            // 
            // pnlCidades
            // 
            this.pnlCidades.Controls.Add(this.label3);
            this.pnlCidades.Controls.Add(this.txtFitnessMinimo);
            this.pnlCidades.Controls.Add(this.button1);
            this.pnlCidades.Controls.Add(this.label2);
            this.pnlCidades.Controls.Add(this.txtPopulacao);
            this.pnlCidades.Controls.Add(this.label1);
            this.pnlCidades.Controls.Add(this.txtMaximo);
            this.pnlCidades.Controls.Add(this.btnGerar);
            this.pnlCidades.Controls.Add(this.txtCidades);
            this.pnlCidades.Controls.Add(this.lblCidades);
            this.pnlCidades.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCidades.Location = new System.Drawing.Point(0, 0);
            this.pnlCidades.Name = "pnlCidades";
            this.pnlCidades.Size = new System.Drawing.Size(724, 45);
            this.pnlCidades.TabIndex = 2;
            // 
            // txtMaximo
            // 
            this.txtMaximo.Location = new System.Drawing.Point(112, 21);
            this.txtMaximo.Name = "txtMaximo";
            this.txtMaximo.Size = new System.Drawing.Size(100, 20);
            this.txtMaximo.TabIndex = 3;
            // 
            // btnGerar
            // 
            this.btnGerar.Location = new System.Drawing.Point(430, 20);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(75, 22);
            this.btnGerar.TabIndex = 6;
            this.btnGerar.Text = "Gerar";
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // pnlDistancias
            // 
            this.pnlDistancias.Controls.Add(this.grdDistancias);
            this.pnlDistancias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDistancias.Location = new System.Drawing.Point(0, 45);
            this.pnlDistancias.Name = "pnlDistancias";
            this.pnlDistancias.Size = new System.Drawing.Size(724, 286);
            this.pnlDistancias.TabIndex = 3;
            // 
            // grdDistancias
            // 
            this.grdDistancias.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grdDistancias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDistancias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDistancias.Location = new System.Drawing.Point(0, 0);
            this.grdDistancias.Name = "grdDistancias";
            this.grdDistancias.RowHeadersVisible = false;
            this.grdDistancias.Size = new System.Drawing.Size(724, 286);
            this.grdDistancias.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Distância Máxima";
            // 
            // txtPopulacao
            // 
            this.txtPopulacao.Location = new System.Drawing.Point(218, 21);
            this.txtPopulacao.Name = "txtPopulacao";
            this.txtPopulacao.Size = new System.Drawing.Size(100, 20);
            this.txtPopulacao.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "% População";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(511, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Teste";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtFitnessMinimo
            // 
            this.txtFitnessMinimo.Location = new System.Drawing.Point(324, 21);
            this.txtFitnessMinimo.Name = "txtFitnessMinimo";
            this.txtFitnessMinimo.Size = new System.Drawing.Size(100, 20);
            this.txtFitnessMinimo.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(321, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "% Fitness Mínimo";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 331);
            this.Controls.Add(this.pnlDistancias);
            this.Controls.Add(this.pnlCidades);
            this.Name = "Form1";
            this.Text = "Form1";
            this.pnlCidades.ResumeLayout(false);
            this.pnlCidades.PerformLayout();
            this.pnlDistancias.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDistancias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtCidades;
        private System.Windows.Forms.Label lblCidades;
        private System.Windows.Forms.Panel pnlCidades;
        private System.Windows.Forms.Panel pnlDistancias;
        private System.Windows.Forms.DataGridView grdDistancias;
        private System.Windows.Forms.Button btnGerar;
        private System.Windows.Forms.TextBox txtMaximo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPopulacao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFitnessMinimo;
    }
}

