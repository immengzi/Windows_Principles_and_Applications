// dll_cpp.cpp : 定义 DLL 应用程序的导出函数。

#include "stdafx.h"
#include "dll_cpp.h"
#include "stdlib.h"

int __stdcall testFac(int a) {
	if (a <= 1) return 1;
	return a * testFac(a - 1);
}

int __stdcall testMinus(int a, int b) {
	return abs(a - b);
}