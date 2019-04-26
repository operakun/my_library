using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmazonReviewCrawler
{
    public partial class gui: UserControl
    {
        public gui()
        {
            InitializeComponent();
            tbProductCode.Text = "489100455X";
        }

        private async void BtnGetData_Click(object sender, EventArgs e)
        {
            btnGetData.Enabled = false;
            txtWorkStatus.Text = "処理中…";
            await GetAmazonDataAsync();
            btnGetData.Enabled = true;
            txtWorkStatus.Text = "完了";
        }

        private async Task GetAmazonDataAsync()
        {
            //download target amazon Page
            var clawler = new Crawler(tbProductCode.Text);
            txtWorkStatus.Text = "ページ取得中…";
            bool bResult = await Task<bool>.Run(() => clawler.GetPageHTML());
            if (bResult == false)
            {
                MessageBox.Show("商品コードのページが存在しません");
                return;
            }

            //extract amazon review count
            txtWorkStatus.Text = "レビュー数取得中…";
            lvReviewCount.Items.Clear();
            string strReviewCount = await Task<string>.Run(() => clawler.ExtractReviewCount());
            if (strReviewCount == "")
            {
                MessageBox.Show("レビュー数を取得出来ませんでした");
                return;
            }
            else
            {
                string[] itemData = { "レビュー数", strReviewCount };
                lvReviewCount.Items.Add(new ListViewItem(itemData));
            }

            //extract star count
            txtWorkStatus.Text = "評価割合取得中…";
            Dictionary<int, string> dicReviewStarCount = 
                await Task<Dictionary<int,String>>.Run(() =>clawler.ExtractReviewStarCount());
            for (int i = 5; i > 0; i--)
            {
                string[] itemData = { "★" + i.ToString(), dicReviewStarCount[i] };
                lvReviewCount.Items.Add(new ListViewItem(itemData));
            }
        }

    }
}
