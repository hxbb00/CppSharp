#include "AST.h"
#include "Sources.h"
#include "CppParser.h"

#ifdef BUILD_AARCH64
extern "C" {
	CS_API void Patch_CppParserOptions_getClangVersion(std::string& cstrVersion
		, CppSharp::CppParser::CppParserOptions* pCppParserOptions);

	CS_API void Patch_BlockCommandComment_getArguments(CppSharp::CppParser::AST::BlockCommandComment::Argument& aOut
		, CppSharp::CppParser::AST::BlockCommandComment* pBlockContentComment, unsigned i);

	CS_API void Patch_CommandComment_getArguments(CppSharp::CppParser::AST::InlineCommandComment::Argument& aOut
		, CppSharp::CppParser::AST::InlineCommandComment* pInlineCommandComment, unsigned i);

	CS_API void Patch_HTMLStartTagComment_getAttributes(CppSharp::CppParser::AST::HTMLStartTagComment::Attribute& aOut
		, CppSharp::CppParser::AST::HTMLStartTagComment* pHTMLStartTagComment, unsigned i);

	CS_API void Patch_TemplateSpecializationType_getArguments(CppSharp::CppParser::AST::TemplateArgument& aOut
		, CppSharp::CppParser::AST::TemplateSpecializationType* pTemplateSpecializationType, unsigned i);

	CS_API void Patch_DependentTemplateSpecializationType_getArguments(CppSharp::CppParser::AST::TemplateArgument& aOut
		, CppSharp::CppParser::AST::DependentTemplateSpecializationType* pTemplateSpecializationType, unsigned i);

	CS_API void Patch_ClassLayout_getVFTables(CppSharp::CppParser::AST::VFTableInfo& aOut
		, CppSharp::CppParser::AST::ClassLayout* pClassLayout, unsigned i);

	CS_API void Patch_ClassLayout_getFields(CppSharp::CppParser::AST::LayoutField& aOut
		, CppSharp::CppParser::AST::ClassLayout* pClassLayout, unsigned i);

	CS_API void Patch_ClassLayout_getBases(CppSharp::CppParser::AST::LayoutBase& aOut
		, CppSharp::CppParser::AST::ClassLayout* pClassLayout, unsigned i);

	CS_API void Patch_ClassTemplateSpecialization_getArguments(CppSharp::CppParser::AST::TemplateArgument& aOut
		, CppSharp::CppParser::AST::ClassTemplateSpecialization* pClassTemplateSpecialization, unsigned i);

	CS_API void Patch_FunctionTemplateSpecialization_getArguments(CppSharp::CppParser::AST::TemplateArgument& aOut
		, CppSharp::CppParser::AST::FunctionTemplateSpecialization* pFunctionTemplateSpecialization, unsigned i);

	CS_API void Patch_VarTemplateSpecialization_getArguments(CppSharp::CppParser::AST::TemplateArgument& aOut
		, CppSharp::CppParser::AST::VarTemplateSpecialization* pVarTemplateSpecialization, unsigned i);

	CS_API void Patch_ParserResult_getDiagnostics(CppSharp::CppParser::ParserDiagnostic& aOut
		, CppSharp::CppParser::ParserResult* pParserResult, unsigned i);
}

#endif