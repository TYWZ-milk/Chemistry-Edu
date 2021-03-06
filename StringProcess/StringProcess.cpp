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

void _stdcall BubbleSort(int* pData, int Count)
{
	int iTemp;
	for (int i = 1; i<Count; i++)
	{
		for (int j = Count - 1; j >= 1; j--)
		{
			if (pData[j]<pData[j - 1])
			{
				iTemp = pData[j - 1];
				pData[j - 1] = pData[j];
				pData[j] = iTemp;
			}
		}
	}
}

void _stdcall quickSort(int s[], int l, int r)
{
	if (l< r)
	{
		int i = l, j = r, x = s[l];
		while (i < j)
		{
			while (i < j && s[j] >= x) // 从右向左找第一个小于x的数  
				j--;
			if (i < j)
				s[i++] = s[j];
			while (i < j && s[i]< x) // 从左向右找第一个大于等于x的数  
				i++;
			if (i < j)
				s[j--] = s[i];
		}
		s[i] = x;
		quickSort(s, l, i - 1); // 递归调用  
		quickSort(s, i + 1, r);
	}
}

//非递归查找
int _stdcall BinarySearch(int *array, int aSize, int key)
{
	if (array == NULL || aSize == 0)
		return -1;
	int low = 0;
	int high = aSize - 1;
	int mid = 0;

	while (low <= high)
	{
		mid = (low + high) / 2;

		if (array[mid] < key)
			low = mid + 1;
		else if (array[mid] > key)
			high = mid - 1;
		else
			return mid;
	}
	return -1;
}
//递归
int _stdcall BinarySearchRecursive(int *array, int low, int high, int key)
{
	if (low > high)
		return -1;
	int mid = (low + high) / 2;

	if (array[mid] == key)
		return mid;
	else if (array[mid] < key)
		return BinarySearchRecursive(array, mid + 1, high, key);
	else
		return BinarySearchRecursive(array, low, mid - 1, key);
}

bool _stdcall AllisNum(string str)
{
	for (int i = 0; i < str.size(); i++)
	{
		int tmp = (int)str[i];
		if (tmp >= 48 && tmp <= 57)
		{
			continue;
		}
		else
		{
			return false;
		}
	}
	return true;
}

void _stdcall InsertSort(int arr[], int len) {
	int i, j;
	int temp;
	for (i = 1; i < len; i++) {
		temp = arr[i];
		for (j = i - 1; j >= 0 && arr[j] > temp; j--)
			arr[j + 1] = arr[j];
		arr[j + 1] = temp;
	}
}