// dllmain.h: 模块类的声明。

class CCOMModule : public ATL::CAtlDllModuleT< CCOMModule >
{
public :
	DECLARE_LIBID(LIBID_COMLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_COM, "{a0cbc9a7-89b1-4a4d-96ef-b928341a28ea}")
};

extern class CCOMModule _AtlModule;
