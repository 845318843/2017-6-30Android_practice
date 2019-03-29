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
	//�ҵĳ�����Ϣ
	private LinearLayout LinearLayout_CommonMessage;
	//�ҵ��ر�����
	private LinearLayout LinearLayout_SpecialMessage;
	//�ҵ����
	private LinearLayout LinearLayout_MyMoney;
	//�ҵĵ�ַ
	private LinearLayout LinearLayout_MyAddress;
	//�ҵ���ϵ��ʽ
	private LinearLayout LinearLayout_MyTel;
	//�ҵ���ʵ����
	private LinearLayout LinearLayout_MyName;
	//�ҵ��˺�����
	private LinearLayout LinearLayout_MyAccount;
	//�ҵ�����ʷ��Ϣ����
	private LinearLayout LinearLayout_MyMS_Count;
	//�ҵ����Ͻ��ŷ�
	private ImageView ImageView_Mail;

	@Override   /* �󶨵������ ȫд�ڴ�  */
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

	@Override   /* ������� ȫд�ڴ�  */
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
	@Override /* �ص� */
	protected void onActivityResult(int requestCode, int resultCode, Intent data) {
		switch (requestCode) {/* 1�ǵ�½״̬  2�ǿ���Ϣ���˶���Ǯ��Ӧ���¸�������ҳ */
		case 1:
			if (resultCode == RESULT_OK) {	 
				e_user =  (E_User) data.getSerializableExtra("data_return");
				Log.d("MineA", e_user.user_Account);
				setform(e_user);		
			}
			else if( resultCode == RESULT_CANCELED ){
				e_user =  (E_User) data.getSerializableExtra("data_return");
				Log.d("MineA", e_user.user_Account);
				Log.d("MineA","��½��֤��ͨ��");
			}
		case 2:
			break;
		default:
		}
	}
	/** 2017��6��29��17:17:24  
	 *  �û���½�ɹ��� �û���ϸ���� ������Ӧ�ĸı�
	 * @param e_user
	 */
	private void setform(E_User e_user) {
		/* ���ϵ��µı仯����Ϊ */
		LinearLayout LinearLayout_LoginHine = (LinearLayout) findViewById(R.id.LinearLayout_LoginHine);
		LinearLayout_LoginHine.setVisibility(View.GONE);


		TextView TextView_Money = (TextView) findViewById(R.id.TextView_Money);
		TextView_Money.setText(  e_user.user_Account    );
		TextView TextView_Address = (TextView) findViewById(R.id.TextView_Address);
		TextView_Address.setText(  e_user.user_Address    );
		TextView TextView_Tel = (TextView) findViewById(R.id.TextView_Tel);
		TextView_Tel.setText(  e_user.user_Tel    );


		Log.d("MineA","�û�����ҳ�������");
	}

}
