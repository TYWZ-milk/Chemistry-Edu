// StringProcess.cpp: 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"
#include "StringProcess.h"
#include <string>
using namespace std;
int _stdcall addOne(int ID) {
	return ID + 1;
}

string _stdcall mytoStr(int num) {
	string str = to_string(num);
	return str;
}

int _stdcall mytoInt(string str) {
	int num = atoi(str.c_str());
	return num;
}

