package com.example.sample.activity;

import com.example.sample.R;
import com.example.sample.bean.E_User;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;

public class MineActivity extends Activity implements OnClickListener{

	private E_User e_user=null;
	//我的常规消息
	private LinearLayout LinearLayout_CommonMessage;
	//我的特别推送
	private LinearLayout LinearLayout_SpecialMessage;
	//我的余额
	private LinearLayout LinearLayout_MyMoney;
	//我的地址
	private LinearLayout LinearLayout_MyAddress;
	//我的联系方式
	private LinearLayout LinearLayout_MyTel;
	//我的真实姓名
	private LinearLayout LinearLayout_MyName;
	//我的账号名字
	private LinearLayout LinearLayout_MyAccount;
	//我的总历史消息数量
	private LinearLayout LinearLayout_MyMS_Count;
	//我的右上角信封
	private ImageView ImageView_Mail;

	@Override   /* 绑定点击监听 全写在此  */
	protected void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		setContentView(R.layout.third_mine);
		Button button = (Button) findViewById(R.id.btn_login_person);
		button.setOnClickListener(this);
		LinearLayout_CommonMessage =  (LinearLayout) findViewById(R.id.LinearLayout_CommonMessage);
		LinearLayout_CommonMessage.setOnClickListener(this);
		ImageView_Mail =  (ImageView) findViewById(R.id.ImageView_Mail);
		ImageView_Mail.setOnClickListener(this);
	}

	@Override   /* 点击监听 全写在此  */
	public void onClick(View v) {
		switch (v.getId()) {
		case R.id.btn_login_person:
			Intent intent = new Intent(this, LoginActivity.class);
			startActivityForResult(intent,1);
			break;
		case R.id.LinearLayout_CommonMessage:
			Intent intent2 = new Intent(this, ShangjiaActivity.class);
			intent2.putExtra("e_user",e_user);		       
			startActivityForResult(intent2,2);	
			break;
		case R.id.ImageView_Mail:
			Intent intent3 = new Intent(this, InformActivity.class);
			intent3.putExtra("e_user",e_user);		       
			startActivityForResult(intent3,3);	
			break; 
		default:
			break;
		}
	}
	@Override /* 回调 */
	protected void onActivityResult(int requestCode, int resultCode, Intent data) {
		switch (requestCode) {/* 1是登陆状态  2是看消息扣了多少钱对应更新个人资料页 */
		case 1:
			if (resultCode == RESULT_OK) {	 
				e_user =  (E_User) data.getSerializableExtra("data_return");
				Log.d("MineA", e_user.user_Account);
				setform(e_user);		
			}
			else if( resultCode == RESULT_CANCELED ){
				e_user =  (E_User) data.getSerializableExtra("data_return");
				Log.d("MineA", e_user.user_Account);
				Log.d("MineA","登陆验证不通过");
			}
		case 2:
			break;
		default:
		}
	}
	/** 2017年6月29日17:17:24  
	 *  用户登陆成功， 用户详细界面 发生对应的改变
	 * @param e_user
	 */
	private void setform(E_User e_user) {
		/* 从上到下的变化依次为 */
		LinearLayout LinearLayout_LoginHine = (LinearLayout) findViewById(R.id.LinearLayout_LoginHine);
		LinearLayout_LoginHine.setVisibility(View.GONE);


		TextView TextView_Money = (TextView) findViewById(R.id.TextView_Money);
		TextView_Money.setText(  e_user.user_Account    );
		TextView TextView_Address = (TextView) findViewById(R.id.TextView_Address);
		TextView_Address.setText(  e_user.user_Address    );
		TextView TextView_Tel = (TextView) findViewById(R.id.TextView_Tel);
		TextView_Tel.setText(  e_user.user_Tel    );


		Log.d("MineA","用户资料页设置完成");
	}

}
