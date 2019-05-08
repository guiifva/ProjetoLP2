namespace ProjetoLP2.Forms
{
    partial class Inicial
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpdeskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroFuncionarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentarTestesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpdeskToolStripMenuItem,
            this.cadastroFuncionarioToolStripMenuItem,
            this.documentarTestesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1139, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpdeskToolStripMenuItem
            // 
            this.helpdeskToolStripMenuItem.Name = "helpdeskToolStripMenuItem";
            this.helpdeskToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.helpdeskToolStripMenuItem.Text = "Helpdesk";
            this.helpdeskToolStripMenuItem.Click += new System.EventHandler(this.HelpdeskToolStripMenuItem_Click);
            // 
            // cadastroFuncionarioToolStripMenuItem
            // 
            this.cadastroFuncionarioToolStripMenuItem.Name = "cadastroFuncionarioToolStripMenuItem";
            this.cadastroFuncionarioToolStripMenuItem.Size = new System.Drawing.Size(132, 20);
            this.cadastroFuncionarioToolStripMenuItem.Text = "Cadastro Funcionario";
            this.cadastroFuncionarioToolStripMenuItem.Click += new System.EventHandler(this.CadastroFuncionarioToolStripMenuItem_Click);
            // 
            // documentarTestesToolStripMenuItem
            // 
            this.documentarTestesToolStripMenuItem.Name = "documentarTestesToolStripMenuItem";
            this.documentarTestesToolStripMenuItem.Size = new System.Drawing.Size(120, 20);
            this.documentarTestesToolStripMenuItem.Text = "Documentar Testes";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // Inicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 549);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Inicial";
            this.Text = "Inicial";
            this.Load += new System.EventHandler(this.Inicial_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpdeskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastroFuncionarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentarTestesToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}