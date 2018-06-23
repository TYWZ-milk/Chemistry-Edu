#pragma once
#include <string>
extern "C" _declspec(dllexport) int _stdcall addOne(int ID);
extern "C" _declspec(dllexport) std::string _stdcall mytoStr(int num);
extern "C" _declspec(dllexport) int _stdcall mytoInt(std::string str);