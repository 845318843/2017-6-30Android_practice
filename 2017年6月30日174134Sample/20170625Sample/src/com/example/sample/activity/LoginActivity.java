package com.example.sample.activity;

import com.example.sample.R;
import com.example.sample.bean.E_User;
import com.example.sample.util.UserUtils;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.util.Log;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class LoginActivity  extends Activity  implements OnClickListener{

	public static final String path = "http://172.16.33.134:5057/66666666/mypack/userAction_login";
	private EditText et_username;
	private EditText et_userpwd;
	private Button btn_justlook;

	private Handler handler = new Handler() {
		public void handleMessage(Message msg) {
			
			switch (msg.what) {
			case 'Y':
				Log.d("27行LoginA", "27LoginA");
				E_User e_user = (E_User) msg.obj;
				// 在这里进行UI操作，将结果显示到界面上
				if(e_user.user_Account!="")
				{ 
					Intent intent = new Intent(LoginActivity.this,MineActivity.class); 
					 intent.putExtra("data_return",e_user);
					  setResult(RESULT_OK,intent);					  
					Log.d("登陆到此结束", "登陆到此结束");
					  finish();
				}
				break;
		    case 'N':
		    	Log.d("27行LoginA", "27LoginA");
				E_User e_user2 = (E_User) msg.obj;
				// 在这里进行UI操作，将结果显示到界面上
				if(e_user2.user_Account!="")
				{ 
					Intent intent = new Intent(LoginActivity.this,MineActivity.class); 
					 intent.putExtra("data_return",e_user2);
					  setResult(RESULT_CANCELED,intent);
					Log.d("LoginActivity", "登陆到此结束但是遇到了一点问题");
					finish();
				}
				break;		
			}
		}
	};

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		setContentView(R.layout.login);
		Button button = (Button) findViewById(R.id.btn_login);
		button.setOnClickListener(this);

	}
	@Override
	public void onClick(View v) {
		switch (v.getId()) {
		case R.id.btn_login:
			et_username = (EditText) findViewById(R.id.et_username);
			et_userpwd = (EditText) findViewById(R.id.et_userpwd);
			final String name = et_username.getText().toString() ;
			final String pwd = et_userpwd.getText().toString()    ;
			if (name == "" ||   pwd == "") {
				// 弹出对话框（内容：“请输入Email或手机号”）
			    Toast.makeText(this, "输入格式有误", Toast.LENGTH_LONG).show();
			} 
			else{
				onLogin(name,pwd);
			}
			break;
		default:
			break;
		}
	}
	
	// 判断登录是否成功
	public void onLogin(final String name,final String pwd) {
		//			Map<String, String> data = new HashMap<String, String>();
		//			data.put("user.username", name);
		//			data.put("user.userpwd", pwd);
		//			Log.d("geek", "data=" + data);
		//				final String result = "failure";	 
		// 开启线程来发起网络请求
		new Thread(new Runnable() {
			@Override
			public void run() {			 
				E_User e_userin = new E_User();
				e_userin.user_Account = name;
				e_userin.user_Pw = pwd;
				E_User e_userout = new E_User();
				e_userout = UserUtils.loginResult(e_userin);
				Log.d("geek", "返回结果：" + e_userout.user_Account);
				Log.d("geek", "返回结果：" + e_userout.user_Create_Time);

				if ( e_userout.user_Account!=""  ) {// 登录成功,跳转至
					//					ChangeView();
					//							Toast.makeText(this, result, Toast.LENGTH_LONG).show();
					Message message = new Message();
					message.what = 'Y';
					// 将服务器返回的结果存放到Message中
					message.obj =  e_userout;
					handler.sendMessage(message);			
				} else {
					//							Toast.makeText(this, "登录失败", Toast.LENGTH_LONG).show();
				}
			}
		}).start();
	}


}
