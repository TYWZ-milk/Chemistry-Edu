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

int _stdcall Getlength(char* str) {
	return strlen(str);
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
	else if (type == 2) {
		char s[200] = "<script>alert('账号密码输入错误');history.go(-1);</script>";
		char attr[1024];
		memset(attr, 0, sizeof(attr));
		memcpy(attr, s, sizeof(s));
		memcpy(str, attr, sizeof(attr));
		return 1;
	}
	else if (type == 3) {
		char s[200] = "<script>alert('您已选择该课程');history.go(-1);</script>";
		char attr[1024];
		memset(attr, 0, sizeof(attr));
		memcpy(attr, s, sizeof(s));
		memcpy(str, attr, sizeof(attr));
		return 1;
	}
	else if (type == 4) {
		char s[200] = "<script>alert('密码过短');history.go(-1);</script>";
		char attr[1024];
		memset(attr, 0, sizeof(attr));
		memcpy(attr, s, sizeof(s));
		memcpy(str, attr, sizeof(attr));
		return 1;
	}
	else if (type == 5) {
		char s[200] = "<script>alert('学号格式有误');history.go(-1);</script>";
		char attr[1024];
		memset(attr, 0, sizeof(attr));
		memcpy(attr, s, sizeof(s));
		memcpy(str, attr, sizeof(attr));
		return 1;
	}
	else if (type == 6) {
		char s[200] = "<script>alert('您还仍未选择任何课程');history.go(-1);</script>";
		char attr[1024];
		memset(attr, 0, sizeof(attr));
		memcpy(attr, s, sizeof(s));
		memcpy(str, attr, sizeof(attr));
		return 1;
	}
	else if (type == 7) {
		char s[200] = "<script>alert('该课程已取消');history.go(-1);</script>";
		char attr[1024];
		memset(attr, 0, sizeof(attr));
		memcpy(attr, s, sizeof(s));
		memcpy(str, attr, sizeof(attr));
		return 1;
	}
	else if (type == 8) {
		char s[200] = "<script>alert('该课程已取消');history.go(-1);</script>";
		char attr[1024];
		memset(attr, 0, sizeof(attr));
		memcpy(attr, s, sizeof(s));
		memcpy(str, attr, sizeof(attr));
		return 1;
	}
	else {
		char s[200] = "<script>alert('该文章已不存在');history.go(-1);</script>";
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

