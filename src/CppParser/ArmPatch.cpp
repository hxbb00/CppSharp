#include "ArmPatch.h"
#ifdef BUILD_AARCH64

void Patch_CppParserOptions_getClangVersion(std::string& cstrVersion
	, CppSharp::CppParser::CppParserOptions* pCppParserOptions)
{
	cstrVersion = pCppParserOptions->getClangVersion();
}

void Patch_BlockCommandComment_getArguments(CppSharp::CppParser::AST::BlockCommandComment::Argument& aOut
	, CppSharp::CppParser::AST::BlockCommandComment* pBlockContentComment, unsigned i)
{
	aOut = pBlockContentComment->getArguments(i);
}

void Patch_CommandComment_getArguments(CppSharp::CppParser::AST::InlineCommandComment::Argument& aOut
	, CppSharp::CppParser::AST::InlineCommandComment* pInlineCommandComment, unsigned i)
{
	aOut = pInlineCommandComment->getArguments(i);
}

void Patch_HTMLStartTagComment_getAttributes(CppSharp::CppParser::AST::HTMLStartTagComment::Attribute& aOut
	, CppSharp::CppParser::AST::HTMLStartTagComment* pHTMLStartTagComment, unsigned i) {

	aOut = pHTMLStartTagComment->getAttributes(i);
}

void Patch_TemplateSpecializationType_getArguments(CppSharp::CppParser::AST::TemplateArgument& aOut
	, CppSharp::CppParser::AST::TemplateSpecializationType* pTemplateSpecializationType, unsigned i) {

	aOut = pTemplateSpecializationType->getArguments(i);
}

void Patch_DependentTemplateSpecializationType_getArguments(CppSharp::CppParser::AST::TemplateArgument& aOut
	, CppSharp::CppParser::AST::DependentTemplateSpecializationType* pTemplateSpecializationType, unsigned i) {
	aOut = pTemplateSpecializationType->getArguments(i);
}

void Patch_ClassLayout_getVFTables(CppSharp::CppParser::AST::VFTableInfo& aOut
	, CppSharp::CppParser::AST::ClassLayout* pClassLayout, unsigned i)
{
	aOut = pClassLayout->getVFTables(i);
}

void Patch_ClassLayout_getFields(CppSharp::CppParser::AST::LayoutField& aOut
	, CppSharp::CppParser::AST::ClassLayout* pClassLayout, unsigned i) {

	aOut = pClassLayout->getFields(i);
}

void Patch_ClassLayout_getBases(CppSharp::CppParser::AST::LayoutBase& aOut
	, CppSharp::CppParser::AST::ClassLayout* pClassLayout, unsigned i) {

	aOut = pClassLayout->getBases(i);
}

void Patch_ClassTemplateSpecialization_getArguments(CppSharp::CppParser::AST::TemplateArgument& aOut
	, CppSharp::CppParser::AST::ClassTemplateSpecialization* pClassTemplateSpecialization, unsigned i) {
	aOut = pClassTemplateSpecialization->getArguments(i);
}

void Patch_FunctionTemplateSpecialization_getArguments(CppSharp::CppParser::AST::TemplateArgument& aOut
	, CppSharp::CppParser::AST::FunctionTemplateSpecialization* pFunctionTemplateSpecialization, unsigned i) {
	aOut = pFunctionTemplateSpecialization->getArguments(i);
}

void Patch_VarTemplateSpecialization_getArguments(CppSharp::CppParser::AST::TemplateArgument& aOut
	, CppSharp::CppParser::AST::VarTemplateSpecialization* pVarTemplateSpecialization, unsigned i) {
	aOut = pVarTemplateSpecialization->getArguments(i);
}

void Patch_ParserResult_getDiagnostics(CppSharp::CppParser::ParserDiagnostic& aOut
	, CppSharp::CppParser::ParserResult* pParserResult, unsigned i) {
	aOut = pParserResult->getDiagnostics(i);
}

#endif