// Win32 DLL.cpp: 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include "Win32 DLL.h"
using namespace std;
int _stdcall compare(int a, int b) {
	if (a == b) {
		return 0;
	}
	else {
		return 1;
	}
}

int _stdcall ErrorMessage(int type, char* str) {

	if (type == 0) {
		char s[200] = "<script>alert('该学号已注册');history.go(-1);</script>";
		char attr[1024];
		memset(attr, 0, sizeof(attr));
		memcpy(attr, s, sizeof(s));
		memcpy(str, attr, sizeof(attr));
		return 1;
	}
	else {
		char s[200] = "<script>alert('两次输入密码不一致');history.go(-1);</script>";
		char attr[1024];
		memset(attr, 0, sizeof(attr));
		memcpy(attr, s, sizeof(s));
		memcpy(str, attr, sizeof(attr));
		return 1;
		//return "<script>alert('两次输入密码不一致');history.go(-1);</script>";
	}
}
int _stdcall addOne(int ID) {
	return ID + 1;
}

