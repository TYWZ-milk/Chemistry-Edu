#pragma once
#include <string>
extern "C" _declspec(dllexport) int _stdcall addOne(int ID);
extern "C" _declspec(dllexport) std::string _stdcall mytoStr(int num);
extern "C" _declspec(dllexport) int _stdcall mytoInt(std::string str);
extern "C" _declspec(dllexport) void _stdcall BubbleSort(int* pData, int Count);
extern "C" _declspec(dllexport) void _stdcall quickSort(int s[], int l, int r);
extern "C" _declspec(dllexport) int _stdcall BinarySearch(int *array, int aSize, int key);
extern "C" _declspec(dllexport) int _stdcall BinarySearchRecursive(int *array, int low, int high, int key);
extern "C" _declspec(dllexport) bool _stdcall AllisNum(std::string str);
extern "C" _declspec(dllexport) void _stdcall InsertSort(int arr[], int len);