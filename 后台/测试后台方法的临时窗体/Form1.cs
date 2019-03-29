using BLL;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 测试后台方法的临时窗体
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BLL_Message message1 = new BLL_Message();
            MessageEN ins = new MessageEN();
            ins.message_Region = "北京中关村苹果体验店";
            ins.message_Industry = "电子产品手机";
            ins.message_Title = "急需600台 iphone 8";
            ins.message_Content = "因业务扩展 急需600台 iphone 8 有意联系 13271321583";
            ins.message_Pic = GetBit();
            ins.message_Time = System.DateTime.Now;
            ins.message_State = "";
            ins.message_Creator = "黑手党";
            ins.message_Checker = "管理员小芳";
            //ins.remark1 = "";
            //ins.remark2 = "";
            message1.InsertMessage(ins);
        }

        private byte[] GetBit()
        {
            FileStream fs = new FileStream(@"D:\vcredist.bmp", FileMode.Open, FileAccess.Read);
            Byte[] btye2 = new byte[fs.Length];
            fs.Read(btye2, 0, Convert.ToInt32(fs.Length));
            fs.Close();
            return btye2;
        }

        #region   注释的代码
        //private byte[] GetBit()
        //{
        //    //FileStream fs = new FileStream(@"D:\vcredist.bmp", FileMode.Open);
        //    //BinaryReader br = new BinaryReader(fs);
        //    //Byte[] byData = br.ReadBytes((int)fs.Length);
        //    //fs.Close();
        //    //return byData;


        //    //using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnetString"].ConnectionString.ToString()))
        //    //{
        //    //    conn.Open();
        //    //    SqlCommand cmd = new SqlCommand();
        //    //    cmd.Connection = conn;
        //    //    cmd.CommandText = "insert into Message(imgfile) values(@imgfile)";
        //    //    SqlParameter par = new SqlParameter("@message_Pic", SqlDbType.Image);
        //    //    par.Value = bt;
        //    //    cmd.Parameters.Add(par);
        //    //    int t = (int)(cmd.ExecuteNonQuery());
        //    //    if (t > 0)
        //    //    {
        //    //        Console.WriteLine("插入成功");
        //    //    }
        //    //    conn.Close();
        //    //}

        //    //将需要存储的图片读取为数据流
        //    FileStream fs = new FileStream(@"D:\vcredist.bmp", FileMode.Open, FileAccess.Read);
        //    Byte[] btye2 = new byte[fs.Length];
        //    fs.Read(btye2, 0, Convert.ToInt32(fs.Length));
        //    fs.Close();


        //    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnetString"].ConnectionString.ToString());
        //    conn.Open();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = conn;
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = string.Format("insert into Message(message_Pic) values(@Content)");
        //    cmd.Parameters.Add("@Content", SqlDbType.Binary, btye2.Length);
        //    cmd.Parameters["@Content"].Value = btye2;

        //    int nAffectRows = cmd.ExecuteNonQuery();

        //    return btye2;
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnetString"].ConnectionString.ToString());
        //    conn.Open();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = conn;
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = string.Format("select message_Pic from Message where message_Id=2");
        //    SqlDataReader reader = cmd.ExecuteReader();

        //    if (!reader.HasRows)
        //    {
        //        reader.Close();
        //        MessageBox.Show("Cannot find the label record.");
        //        conn.Close();
        //        return;
        //    }

        //    reader.Read();

        //     byte[] buff = new byte[1];

        //    if (!reader.IsDBNull(0))
        //    {   buff = (byte[])reader[0];
        //    conn.Close();
        //    }

        //     MemoryStream ms = new MemoryStream(); //新建内存流
        //            ms.Write(buff, 0, buff.Length); //附值
        //    pictureBox1.Image = Image.FromStream(ms); //读取流中内容
        //}
        #endregion


        private void button2_Click(object sender, EventArgs e)
        {
            //BLL_Message message1 = new BLL_Message();
            //List<MessageEN> ins = message1.FindMessage_ByRegionOrIndustry("北京", "");
            //byte[] buff = ins[0].message_Pic;


            //            MemoryStream ms = new MemoryStream(); //新建内存流
            //        ms.Write(buff, 0, buff.Length); //附值
            //        int a = buff.Length;
            //pictureBox1.Image = Image.FromStream(ms); //读取流中内容

        }
    }
}
