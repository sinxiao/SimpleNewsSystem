﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace WoeMobile.Web.news
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtintro.Text.Trim().Length==0)
			{
				strErr+="intro不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtgen_time.Text))
			{
				strErr+="gen_time格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtwriter.Text))
			{
				strErr+="writer格式错误！\\n";	
			}
			if(this.txttitle.Text.Trim().Length==0)
			{
				strErr+="title不能为空！\\n";	
			}
			if(this.txtcontent.Text.Trim().Length==0)
			{
				strErr+="content不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtitemid.Text))
			{
				strErr+="itemid格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtpasscheked.Text))
			{
				strErr+="passcheked格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtkeyword.Text))
			{
				strErr+="keyword格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtdefault_news.Text))
			{
				strErr+="default_news格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtclicked.Text))
			{
				strErr+="clicked格式错误！\\n";	
			}
			if(this.txtnews_url.Text.Trim().Length==0)
			{
				strErr+="news_url不能为空！\\n";	
			}
			if(this.txtimage_url.Text.Trim().Length==0)
			{
				strErr+="image_url不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtcomment_sum.Text))
			{
				strErr+="comment_sum格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string intro=this.txtintro.Text;
			DateTime gen_time=DateTime.Parse(this.txtgen_time.Text);
			int writer=int.Parse(this.txtwriter.Text);
			string title=this.txttitle.Text;
			string content=this.txtcontent.Text;
			int itemid=int.Parse(this.txtitemid.Text);
			int passcheked=int.Parse(this.txtpasscheked.Text);
			String keyword=(this.txtkeyword.Text);
			int default_news=int.Parse(this.txtdefault_news.Text);
			int clicked=int.Parse(this.txtclicked.Text);
			string news_url=this.txtnews_url.Text;
			string image_url=this.txtimage_url.Text;
			int comment_sum=int.Parse(this.txtcomment_sum.Text);

			WoeMobile.Model.news model=new WoeMobile.Model.news();
			model.intro=intro;
			model.gen_time=gen_time;
			model.writer=writer;
			model.title=title;
			model.content=content;
			model.itemid=itemid;
			model.passcheked=passcheked;
			model.keyword=keyword;
			model.default_news=default_news;
			model.clicked=clicked;
			model.news_url=news_url;
			model.image_url=image_url;
			model.comment_sum=comment_sum;

			WoeMobile.BLL.NewsManager bll=new WoeMobile.BLL.NewsManager();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
