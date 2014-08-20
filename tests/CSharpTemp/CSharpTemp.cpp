#include "CSharpTemp.h"

Foo::Foo()
{
    A = 10;
    P = 50;
}

int Foo::method()
{
    return 1;
}

int Foo::operator[](int i) const
{
    return 5;
}

int Foo::operator[](unsigned int i)
{
    return 15;
}

int& Foo::operator[](int i)
{
    return P;
}

const Foo& Bar::operator[](int i) const
{
    return m_foo;
}

Qux::Qux()
{

}

Qux::Qux(Foo foo)
{

}

int Qux::farAwayFunc() const
{
    return 20;
}

void Qux::obsolete()
{

}

int Bar::method()
{
    return 2;
}

Foo& Bar::operator[](int i)
{
    return m_foo;
}

Bar Bar::operator *()
{
    return *this;
}

const Bar& Bar::operator *(int m)
{
    index *= m;
    return *this;
}

const Bar& Bar::operator ++()
{
    ++index;
    return *this;
}

Bar Bar::operator ++(int i)
{
    Bar bar = *this;
    index++;
    return bar;
}

int Baz::takesQux(const Qux& qux)
{
    return qux.farAwayFunc();
}

Qux Baz::returnQux()
{
    return Qux();
}

int AbstractProprietor::getValue()
{
    return m_value;
}

void AbstractProprietor::setProp(long property)
{
    m_property = property;
}

int AbstractProprietor::parent()
{
    return 0;
}

void Proprietor::setValue(int value)
{
    m_value = value;
}

long Proprietor::prop()
{
    return m_property;
}

void P::setValue(int value)
{
    m_value = value + 10;
}

long P::prop()
{
    return m_property + 100;
}

template <typename T>
QFlags<T>::QFlags(T t) : flag(t)
{
}

template <typename T>
QFlags<T>::operator T()
{
    return flag;
}

ComplexType::ComplexType() : qFlags(QFlags<TestFlag>(TestFlag::Flag2))
{
}

int ComplexType::check()
{
    return 5;
}

QFlags<TestFlag> ComplexType::returnsQFlags()
{
    return qFlags;
}

void ComplexType::takesQFlags(const QFlags<int> f)
{

}

P::P(const Qux &qux)
{

}

P::P(Qux *qux)
{

}

ComplexType P::complexType()
{
    return m_complexType;
}

void P::setComplexType(const ComplexType& value)
{
    m_complexType = value;
}

void P::parent(int i)
{

}

bool P::isTest()
{
    return true;
}

void P::setTest(bool value)
{

}

void P::test()
{

}

bool P::isBool()
{
    return false;
}

void P::setIsBool(bool value)
{

}

int TestDestructors::Marker = 0;

TestCopyConstructorVal::TestCopyConstructorVal()
{
}

TestCopyConstructorVal::TestCopyConstructorVal(const TestCopyConstructorVal& other)
{
    A = other.A;
    B = other.B;
}

void MethodsWithDefaultValues::DefaultPointer(Foo *ptr)
{
}

void MethodsWithDefaultValues::DefaultValueType(ValueType bar)
{
}

void MethodsWithDefaultValues::DefaultChar(char c)
{
}

void MethodsWithDefaultValues::DefaultRefTypeBeforeOthers(Foo foo, int i, Bar::Items item)
{
}

void MethodsWithDefaultValues::DefaultRefTypeAfterOthers(int i, Bar::Items item, Foo foo)
{
}

void MethodsWithDefaultValues::DefaultRefTypeBeforeAndAfterOthers(int i, Foo foo, Bar::Items item, Baz baz)
{
}

void MethodsWithDefaultValues::DefaultIntAssignedAnEnum(int i)
{
}

void HasPrivateOverrideBase::privateOverride(int i)
{
}

void HasPrivateOverride::privateOverride(int i)
{
}

IgnoredType<int> PropertyWithIgnoredType::ignoredType()
{
    return _ignoredType;
}

void PropertyWithIgnoredType::setIgnoredType(const IgnoredType<int> &value)
{
    _ignoredType = value;
}
