#pragma once
#include <string>
extern "C" _declspec(dllexport) int _stdcall compare(int a, int b);
extern "C" _declspec(dllexport) int _stdcall ErrorMessage(int type, char* str);
extern "C" _declspec(dllexport) int _stdcall addOne(int ID);