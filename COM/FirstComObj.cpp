// FirstComObj.cpp: CFirstComObj 的实现

#include "stdafx.h"
#include "FirstComObj.h"


// CFirstComObj

STDMETHODIMP CFirstComObj::AddOne_COM(LONG a, LONG * result) {
	*result = a  + 1;
	return S_OK; // STDMETHODIMP，S_OK都是宏
}