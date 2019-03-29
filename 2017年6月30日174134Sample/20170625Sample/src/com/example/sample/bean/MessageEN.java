package com.example.sample.bean;

import java.io.Serializable;
import java.sql.Timestamp;

public  class MessageEN  implements Serializable {
	public int _message_Id;
	public String _message_Region;
	public String _message_Industry;
	public String _message_Title;
	public String _message_Content;
//	public byte[] _message_Pic;
//	public Timestamp _message_Time;
	public String _message_State;
	public String _message_Creator;
	public String _message_Checker;
	public String _remark1;
	public String _remark2;

	static public boolean primary(String AttributeName){       
		if(AttributeName=="message_Id")  {
			return false;
		}
		else{
			return true;
		}             
	}
}
