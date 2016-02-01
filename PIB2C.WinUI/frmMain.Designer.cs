namespace PIB2C.WinUI
{
    partial class frmMain
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
            this.btnProcurarAnexo = new System.Windows.Forms.Button();
            this.txtArquivo = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnImportar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblImportarArquivo = new System.Windows.Forms.Label();
            this.lblPIB = new System.Windows.Forms.Label();
            this.lbl2C = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblTotalPedidos = new System.Windows.Forms.Label();
            this.txtTotalPedidos = new System.Windows.Forms.TextBox();
            this.lblTotalProdutos = new System.Windows.Forms.Label();
            this.txtTotalProdutos = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProcurarAnexo
            // 
            this.btnProcurarAnexo.Location = new System.Drawing.Point(389, 88);
            this.btnProcurarAnexo.Name = "btnProcurarAnexo";
            this.btnProcurarAnexo.Size = new System.Drawing.Size(70, 20);
            this.btnProcurarAnexo.TabIndex = 0;
            this.btnProcurarAnexo.Text = "Procurar...";
            this.btnProcurarAnexo.UseVisualStyleBackColor = true;
            this.btnProcurarAnexo.Click += new System.EventHandler(this.btnProcurarAnexo_Click);
            // 
            // txtArquivo
            // 
            this.txtArquivo.Location = new System.Drawing.Point(15, 88);
            this.txtArquivo.Name = "txtArquivo";
            this.txtArquivo.Size = new System.Drawing.Size(368, 20);
            this.txtArquivo.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "Selecione uma planilha";
            this.openFileDialog1.Filter = "Arquivo CSV|*.csv";
            // 
            // btnImportar
            // 
            this.btnImportar.Location = new System.Drawing.Point(15, 114);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(117, 21);
            this.btnImportar.TabIndex = 2;
            this.btnImportar.Text = "Importar";
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(949, 287);
            this.dataGridView1.TabIndex = 3;
            // 
            // lblImportarArquivo
            // 
            this.lblImportarArquivo.AutoSize = true;
            this.lblImportarArquivo.Location = new System.Drawing.Point(12, 69);
            this.lblImportarArquivo.Name = "lblImportarArquivo";
            this.lblImportarArquivo.Size = new System.Drawing.Size(162, 13);
            this.lblImportarArquivo.TabIndex = 4;
            this.lblImportarArquivo.Text = "Importe um Arquivo para Análise:";
            // 
            // lblPIB
            // 
            this.lblPIB.AutoSize = true;
            this.lblPIB.Font = new System.Drawing.Font("Tempus Sans ITC", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPIB.Location = new System.Drawing.Point(4, 7);
            this.lblPIB.Name = "lblPIB";
            this.lblPIB.Size = new System.Drawing.Size(96, 62);
            this.lblPIB.TabIndex = 5;
            this.lblPIB.Text = "PIB";
            // 
            // lbl2C
            // 
            this.lbl2C.AutoSize = true;
            this.lbl2C.Font = new System.Drawing.Font("Ravie", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2C.Location = new System.Drawing.Point(84, 27);
            this.lbl2C.Name = "lbl2C";
            this.lbl2C.Size = new System.Drawing.Size(43, 26);
            this.lbl2C.TabIndex = 6;
            this.lbl2C.Text = "2C";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 3);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(949, 287);
            this.dataGridView2.TabIndex = 7;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 500);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(963, 17);
            this.progressBar1.TabIndex = 10;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            // 
            // lblTotalPedidos
            // 
            this.lblTotalPedidos.AutoSize = true;
            this.lblTotalPedidos.Location = new System.Drawing.Point(12, 157);
            this.lblTotalPedidos.Name = "lblTotalPedidos";
            this.lblTotalPedidos.Size = new System.Drawing.Size(75, 13);
            this.lblTotalPedidos.TabIndex = 11;
            this.lblTotalPedidos.Text = "Total Pedidos:";
            // 
            // txtTotalPedidos
            // 
            this.txtTotalPedidos.Location = new System.Drawing.Point(94, 157);
            this.txtTotalPedidos.Name = "txtTotalPedidos";
            this.txtTotalPedidos.Size = new System.Drawing.Size(100, 20);
            this.txtTotalPedidos.TabIndex = 12;
            // 
            // lblTotalProdutos
            // 
            this.lblTotalProdutos.AutoSize = true;
            this.lblTotalProdutos.Location = new System.Drawing.Point(219, 160);
            this.lblTotalProdutos.Name = "lblTotalProdutos";
            this.lblTotalProdutos.Size = new System.Drawing.Size(79, 13);
            this.lblTotalProdutos.TabIndex = 13;
            this.lblTotalProdutos.Text = "Total Produtos:";
            // 
            // txtTotalProdutos
            // 
            this.txtTotalProdutos.Location = new System.Drawing.Point(304, 160);
            this.txtTotalProdutos.Name = "txtTotalProdutos";
            this.txtTotalProdutos.Size = new System.Drawing.Size(100, 20);
            this.txtTotalProdutos.TabIndex = 14;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 186);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(963, 319);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(955, 293);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dados Importados";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(955, 293);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Perfis Gerados";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 517);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtTotalProdutos);
            this.Controls.Add(this.lblTotalProdutos);
            this.Controls.Add(this.txtTotalPedidos);
            this.Controls.Add(this.lblTotalPedidos);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lbl2C);
            this.Controls.Add(this.lblPIB);
            this.Controls.Add(this.lblImportarArquivo);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.txtArquivo);
            this.Controls.Add(this.btnProcurarAnexo);
            this.Name = "frmMain";
            this.Text = "PIB2C";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProcurarAnexo;
        private System.Windows.Forms.TextBox txtArquivo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblImportarArquivo;
        private System.Windows.Forms.Label lblPIB;
        private System.Windows.Forms.Label lbl2C;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblTotalPedidos;
        private System.Windows.Forms.TextBox txtTotalPedidos;
        private System.Windows.Forms.Label lblTotalProdutos;
        private System.Windows.Forms.TextBox txtTotalProdutos;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}