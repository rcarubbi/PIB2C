using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PIB2C.WinUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

       
        
        private void btnProcurarAnexo_Click(object sender, EventArgs e)
        {
            var retornoDialogo = openFileDialog1.ShowDialog();
            if (retornoDialogo == System.Windows.Forms.DialogResult.OK)
            {
                txtArquivo.Text = openFileDialog1.FileName;
            }
            else
            {
                txtArquivo.Clear();
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            if(txtArquivo.Text == string.Empty)
            {
                MessageBox.Show(this, "Selecione o arquivo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            progressBar1.Step = 1;
           
            backgroundWorker1.RunWorkerAsync();

            btnImportar.Enabled = false;
            btnProcurarAnexo.Enabled = false;
            tabControl1.SelectedIndex = 0; 
        

        }

        void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BindPreview(null);
            BindResult(null);
            percentProgress = 0;
            IProvedorProdutos provedor = ProvedorProdutosFactory.CreateProvedor();
            provedor.TotalLinhasLido += new EventHandler<TotalLinhasEventArgs>(provedor_TotalLinhasLido);
            provedor.ProdutoLido += new EventHandler(provedor_ProdutoLido);
            var produtos = provedor.ObterProdutos(txtArquivo.Text);
            BindPreview(produtos);

            Analise algoritmoGenetico = new Analise();
            algoritmoGenetico.EtapaConcluida += new EventHandler(algoritmoGenetico_EtapaConcluida);
            var perfis = algoritmoGenetico.Run(produtos);
            BindResult(perfis);

        }

        private void BindResult(List<Perfil> perfis)
        {
            
                if (dataGridView1.InvokeRequired)
                {
                    MethodInvoker del = delegate { BindResult(perfis); };
                    this.Invoke(del);
                }
                else
                {

                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    if (perfis != null)
                    {
                        dataGridView2.DataSource =  perfis.OrderByDescending(p => p.Nota).Select((perfil, id) => 
                                                    new
                                                    {
                                                        ID = id+1,
                                                        Produto1 = perfil.Produtos[0].Nome,
                                                        Produto2 = perfil.Produtos[1].Nome,
                                                        Produto3 = perfil.Produtos[2].Nome,
                                                        Percentual = string.Format("{0:F2} %", perfil.Nota)
                                                    }).ToList();
                    }
                    else
                        dataGridView2.DataSource = perfis;
                    dataGridView2.Refresh();
                    dataGridView2.AutoResizeColumns();
                }

            

        }

        private void BindPreview(List<Produto> produtos)
        {
            
                if (dataGridView1.InvokeRequired)
                {
                    MethodInvoker del = delegate { BindPreview(produtos); };
                    this.Invoke(del);
                }
                else
                {

                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    dataGridView1.DataSource = produtos;
                    dataGridView1.Refresh();
                    dataGridView1.AutoResizeColumns();
                    if (produtos == null)
                    {
                        txtTotalPedidos.Text =
                        txtTotalProdutos.Text = "0"; 
                    }
                    else
                    {
                        txtTotalPedidos.Text = produtos.Select(p => p.CodPedido).Distinct().Count().ToString();
                        txtTotalProdutos.Text = produtos.Count.ToString();
                    }
                }
            
        }

        void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = 0;
            btnImportar.Enabled = true;
            btnProcurarAnexo.Enabled = true;
            tabControl1.SelectedIndex = 1; 
         
        }

        void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }


        private int percentProgress;
        void algoritmoGenetico_EtapaConcluida(object sender, EventArgs e)
        {
            percentProgress+=10;
            if (percentProgress > progressBar1.Maximum)
                percentProgress = progressBar1.Maximum / 2;

            backgroundWorker1.ReportProgress(percentProgress);
           
        }

        void provedor_ProdutoLido(object sender, EventArgs e)
        {
            percentProgress++;

            if (percentProgress > progressBar1.Maximum / 2)
                percentProgress = progressBar1.Maximum / 2;
            backgroundWorker1.ReportProgress(percentProgress);
        }

        void provedor_TotalLinhasLido(object sender, TotalLinhasEventArgs e)
        {
            if (progressBar1.InvokeRequired)
            {
                 MethodInvoker del = delegate { provedor_TotalLinhasLido(sender, e); };

                this.Invoke(del);
                
            }
            else
            {
                progressBar1.Maximum = e.TotalLinhas * 2;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
        }

      

     

    }
    
}
