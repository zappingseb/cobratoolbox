/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 2.0.4
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

namespace libsbml {

 using System;
 using System.Runtime.InteropServices;

/** 
 * @sbmlpackage{core}
 *
@htmlinclude pkg-marker-core.html A delay on the time of execution of an SBML <em>event</em>.
 *
 * An Event object defines when the event can occur, the variables that
 * are affected by the event, and how the variables are affected.  The
 * effect of the event can optionally be delayed after the occurrence of
 * the condition which invokes it.  An event delay is defined using an
 * object of class Delay.
 *
 * The object class Delay is derived from SBase and adds a single
 * subelement called 'math'.  This subelement is used to hold MathML
 * content.  The mathematical formula represented by 'math' must evaluate
 * to a numerical value.  It is used as the length of time between when the
 * event is @em triggered and when the event's assignments are
 * actually @em executed.  If no delay is present on a given Event, a time
 * delay of zero is assumed.
 *
 * The expression in 'math' must be evaluated at the time the event is @em
 * triggered.  The expression must always evaluate to a nonnegative number
 * (otherwise, a nonsensical situation could arise where an event is
 * defined to execute before it is triggered!).
 *
 * @section delay-units The units of the mathematical expression in a Delay
 *
 * In SBML Level&nbsp;2 versions before Version&nbsp;4, the units of the
 * numerical value computed by the Delay's 'math' expression are @em
 * required to be in units of time, or the model is considered to have a
 * unit consistency error.  In Level&nbsp;2 Version&nbsp;4 as well as SBML
 * Level&nbsp;3 Version&nbsp;1 Core, this requirement is relaxed; these
 * specifications only stipulate that the units of the numerical value
 * computed by a Delay instance's 'math' expression @em should match the
 * model's units of time (meaning the definition of the @c time units in
 * the model).  LibSBML respects these requirements, and depending on
 * whether an earlier Version of SBML Level&nbsp;2 is in use, libSBML may
 * or may not flag unit inconsistencies as errors or merely warnings.
 *
 * Note that <em>units are not predefined or assumed</em> for the contents
 * of 'math' in a Delay object; rather, they must be defined explicitly for
 * each instance of a Delay object in a model.  This is an important point
 * to bear in mind when literal numbers are used in delay expressions.  For
 * example, the following Event instance would result in a warning logged
 * by SBMLDocument::checkConsistency() about the fact that libSBML cannot
 * verify the consistency of the units of the expression.  The reason is
 * that the formula inside the 'math' element does not have any declared
 * units, whereas what is expected in this context is units of time:
 * @verbatim
<model>
    ...
    <listOfEvents>
        <event useValuesFromTriggerTime='true'>
            ...
            <delay>
                <math xmlns='http://www.w3.org/1998/Math/MathML'>
                    <cn> 1 </cn>
                </math>
            </delay>
            ...
        </event>
    </listOfEvents>
    ...
</model>
@endverbatim
 * 
 * The <code>&lt;cn&gt; 1 &lt;/cn&gt;</code> within the mathematical formula
 * of the @c delay above has <em>no units declared</em>.  To make the
 * expression have the needed units of time, literal numbers should be
 * avoided in favor of defining Parameter objects for each quantity, and
 * declaring units for the Parameter values.  The following fragment of
 * SBML illustrates this approach:
 * @verbatim
<model>
    ...
    <listOfParameters>
        <parameter id='transcriptionDelay' value='10' units='second'/>
    </listOfParameters>
    ...
    <listOfEvents>
        <event useValuesFromTriggerTime='true'>
            ...
            <delay>
                <math xmlns='http://www.w3.org/1998/Math/MathML'>
                    <ci> transcriptionDelay </ci>
                </math>
            </delay>
            ...
        </event>
    </listOfEvents>
    ...
</model>
@endverbatim
 *
 * In SBML Level&nbsp;3, an alternative approach is available in the form
 * of the @c units attribute, which SBML Level&nbsp;3 allows to appear on
 * MathML @c cn elements.  The value of this attribute can be used to
 * indicate the unit of measurement to be associated with the number in the
 * content of a @c cn element.  The attribute is named @c units but,
 * because it appears inside MathML element (which is in the XML namespace
 * for MathML and not the namespace for SBML), it must always be prefixed
 * with an XML namespace prefix for the SBML Level&nbsp;3 Version&nbsp;1
 * namespace.  The following is an example of this approach:
 * @verbatim
<model timeUnits='second' ...>
    ...
    <listOfEvents>
        <event useValuesFromTriggerTime='true'>
            ...
            <delay>
                <math xmlns='http://www.w3.org/1998/Math/MathML'
                      xmlns:sbml='http://www.sbml.org/sbml/level3/version1/core'>
                    <cn sbml:units='second'> 10 </cn>
                </math>
            </delay>
            ...
        </event>
    </listOfEvents>
    ...
</model>
@endverbatim
 */

public class Delay : SBase {
	private HandleRef swigCPtr;
	
	internal Delay(IntPtr cPtr, bool cMemoryOwn) : base(libsbmlPINVOKE.Delay_SWIGUpcast(cPtr), cMemoryOwn)
	{
		//super(libsbmlPINVOKE.DelayUpcast(cPtr), cMemoryOwn);
		swigCPtr = new HandleRef(this, cPtr);
	}
	
	internal static HandleRef getCPtr(Delay obj)
	{
		return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
	}
	
	internal static HandleRef getCPtrAndDisown (Delay obj)
	{
		HandleRef ptr = new HandleRef(null, IntPtr.Zero);
		
		if (obj != null)
		{
			ptr             = obj.swigCPtr;
			obj.swigCMemOwn = false;
		}
		
		return ptr;
	}

  ~Delay() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          libsbmlPINVOKE.delete_Delay(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  
/**
   * Creates a new Delay using the given SBML @p level and @p version
   * values.
   *
   * @param level a long integer, the SBML Level to assign to this Delay
   *
   * @param version a long integer, the SBML Version to assign to this
   * Delay
   *
   * @throws SBMLConstructorException
   * Thrown if the given @p level and @p version combination, or this kind
   * of SBML object, are either invalid or mismatched with respect to the
   * parent SBMLDocument object.
   *
   * *
 * @note Attempting to add an object to an SBMLDocument having a different
 * combination of SBML Level, Version and XML namespaces than the object
 * itself will result in an error at the time a caller attempts to make the
 * addition.  A parent object must have compatible Level, Version and XML
 * namespaces.  (Strictly speaking, a parent may also have more XML
 * namespaces than a child, but the reverse is not permitted.)  The
 * restriction is necessary to ensure that an SBML model has a consistent
 * overall structure.  This requires callers to manage their objects
 * carefully, but the benefit is increased flexibility in how models can be
 * created by permitting callers to create objects bottom-up if desired.  In
 * situations where objects are not yet attached to parents (e.g.,
 * SBMLDocument), knowledge of the intented SBML Level and Version help
 * libSBML determine such things as whether it is valid to assign a
 * particular value to an attribute.
 *
 *
   */ public
 Delay(long level, long version) : this(libsbmlPINVOKE.new_Delay__SWIG_0(level, version), true) {
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }

  
/**
   * Creates a new Delay using the given SBMLNamespaces object
   * @p sbmlns.
   *
   * *
 * 
 * The SBMLNamespaces object encapsulates SBML Level/Version/namespaces
 * information.  It is used to communicate the SBML Level, Version, and (in
 * Level&nbsp;3) packages used in addition to SBML Level&nbsp;3 Core.  A
 * common approach to using libSBML's SBMLNamespaces facilities is to create an
 * SBMLNamespaces object somewhere in a program once, then hand that object
 * as needed to object constructors that accept SBMLNamespaces as arguments.
 *
 *
   *
   * @param sbmlns an SBMLNamespaces object.
   *
   * @throws SBMLConstructorException
   * Thrown if the given @p level and @p version combination, or this kind
   * of SBML object, are either invalid or mismatched with respect to the
   * parent SBMLDocument object.
   *
   * *
 * @note Attempting to add an object to an SBMLDocument having a different
 * combination of SBML Level, Version and XML namespaces than the object
 * itself will result in an error at the time a caller attempts to make the
 * addition.  A parent object must have compatible Level, Version and XML
 * namespaces.  (Strictly speaking, a parent may also have more XML
 * namespaces than a child, but the reverse is not permitted.)  The
 * restriction is necessary to ensure that an SBML model has a consistent
 * overall structure.  This requires callers to manage their objects
 * carefully, but the benefit is increased flexibility in how models can be
 * created by permitting callers to create objects bottom-up if desired.  In
 * situations where objects are not yet attached to parents (e.g.,
 * SBMLDocument), knowledge of the intented SBML Level and Version help
 * libSBML determine such things as whether it is valid to assign a
 * particular value to an attribute.
 *
 *
   */ public
 Delay(SBMLNamespaces sbmlns) : this(libsbmlPINVOKE.new_Delay__SWIG_1(SBMLNamespaces.getCPtr(sbmlns)), true) {
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }

  
/**
   * Copy constructor; creates a copy of this Delay.
   *
   * @param orig the object to copy.
   * 
   * @throws SBMLConstructorException
   * Thrown if the argument @p orig is @c null.
   */ public
 Delay(Delay orig) : this(libsbmlPINVOKE.new_Delay__SWIG_2(Delay.getCPtr(orig)), true) {
    if (libsbmlPINVOKE.SWIGPendingException.Pending) throw libsbmlPINVOKE.SWIGPendingException.Retrieve();
  }

  
/**
   * Creates and returns a deep copy of this Delay object.
   *
   * @return the (deep) copy of this Delay object.
   */ public new
 Delay clone() {
    IntPtr cPtr = libsbmlPINVOKE.Delay_clone(swigCPtr);
    Delay ret = (cPtr == IntPtr.Zero) ? null : new Delay(cPtr, true);
    return ret;
  }

  
/**
   * Get the mathematical formula for the delay and return it
   * as an AST.
   * 
   * @return the math of this Delay.
   */ public
 ASTNode getMath() {
    IntPtr cPtr = libsbmlPINVOKE.Delay_getMath(swigCPtr);
    ASTNode ret = (cPtr == IntPtr.Zero) ? null : new ASTNode(cPtr, false);
    return ret;
  }

  
/**
   * Predicate to test whether the formula for this delay is set.
   *
   * @return @c true if the formula (meaning the @c math subelement) of
   * this Delay is set, @c false otherwise.
   */ public
 bool isSetMath() {
    bool ret = libsbmlPINVOKE.Delay_isSetMath(swigCPtr);
    return ret;
  }

  
/**
   * Sets the delay expression of this Delay instance to a copy of the given
   * ASTNode.
   *
   * @param math an ASTNode representing a formula tree.
   *
   * *
 * @return integer value indicating success/failure of the
 * function.  @if clike The value is drawn from the
 * enumeration #OperationReturnValues_t. @endif The possible values
 * returned by this function are:
 *
 *
   * @li @link libsbml#LIBSBML_OPERATION_SUCCESS LIBSBML_OPERATION_SUCCESS@endlink
   * @li @link libsbml#LIBSBML_INVALID_OBJECT LIBSBML_INVALID_OBJECT@endlink
   */ public
 int setMath(ASTNode math) {
    int ret = libsbmlPINVOKE.Delay_setMath(swigCPtr, ASTNode.getCPtr(math));
    return ret;
  }

  
/**
   * Calculates and returns a UnitDefinition that expresses the units
   * of measurement assumed for the 'math' expression of this Delay.
   *
   * *
 * 
 * Delay elements in SBML express a time delay for an Event.  Beginning
 * with SBML Level&nbsp;2 Version&nbsp;2, the units of that time are
 * calculated based on the mathematical expression and the model quantities
 * referenced by <code>&lt;ci&gt;</code> elements used within that
 * expression.  (In SBML Level &nbsp;2 Version&nbsp;1, there exists an
 * attribute on Event called 'timeUnits'.  This attribute can be used to set
 * the units of the Delay expression explicitly.)  The method
 * Delay::getDerivedUnitDefinition() returns what libSBML computes the units
 * to be, to the extent that libSBML can compute them.
 *
 *
   *
   * *
 * @note The functionality that facilitates unit analysis depends on the
 * model as a whole.  Thus, in cases where the object has not been added to
 * a model or the model itself is incomplete, unit analysis is not possible
 * and this method will return @c null.
 *
 * 
   *
   * *
 * @warning <span class='warning'>Note that it is possible the 'math'
 * expression in the Delay contains literal numbers or parameters with
 * undeclared units.  In those cases, it is not possible to calculate the
 * units of the overall expression without making assumptions.  LibSBML does
 * not make assumptions about the units, and
 * Delay::getDerivedUnitDefinition() only returns the units as far as it is
 * able to determine them.  For example, in an expression <em>X + Y</em>, if
 * <em>X</em> has unambiguously-defined units and <em>Y</em> does not, it
 * will return the units of <em>X</em>.  When using this method, <strong>it
 * is critical that callers also invoke the method</strong>
 * Delay::containsUndeclaredUnits() <strong>to determine whether this
 * situation holds</strong>.  Callers should take suitable action in those
 * situations.</span>
 *
   * 
   * @return a UnitDefinition that expresses the units of the math 
   * expression of this Delay, or @c null if one cannot be constructed.
   *
   * @see containsUndeclaredUnits()
   */ public
 UnitDefinition getDerivedUnitDefinition() {
    IntPtr cPtr = libsbmlPINVOKE.Delay_getDerivedUnitDefinition__SWIG_0(swigCPtr);
    UnitDefinition ret = (cPtr == IntPtr.Zero) ? null : new UnitDefinition(cPtr, false);
    return ret;
  }

  
/**
   * Predicate returning @c true if the 'math' expression in this Delay
   * instance contains parameters with undeclared units or literal numbers.
   * 
   * *
 * 
 * Delay elements in SBML express a time delay for an Event.  Beginning
 * with SBML Level&nbsp;2 Version&nbsp;2, the units of that time are
 * calculated based on the mathematical expression and the model quantities
 * referenced by <code>&lt;ci&gt;</code> elements used within that
 * expression.  (In SBML Level &nbsp;2 Version&nbsp;1, there exists an
 * attribute on Event called 'timeUnits'.  This attribute can be used to set
 * the units of the Delay expression explicitly.)  The method
 * Delay::getDerivedUnitDefinition() returns what libSBML computes the units
 * to be, to the extent that libSBML can compute them.
 *
 *
   *
   * If the expression contains literal numbers or parameters with undeclared
   * units, <strong>libSBML may not be able to compute the full units of the
   * expression</strong> and will only return what it can compute.  Callers
   * should always use Delay::containsUndeclaredUnits() when using
   * Delay::getDerivedUnitDefinition() to decide whether the returned units
   * may be incomplete.
   * 
   * @return @c true if the math expression of this Delay includes
   * numbers/parameters with undeclared units, @c false otherwise.
   *
   * @note A return value of @c true indicates that the UnitDefinition
   * returned by Delay::getDerivedUnitDefinition() may not accurately
   * represent the units of the expression.
   *
   * @see getDerivedUnitDefinition()
   */ public
 bool containsUndeclaredUnits() {
    bool ret = libsbmlPINVOKE.Delay_containsUndeclaredUnits__SWIG_0(swigCPtr);
    return ret;
  }

  
/**
   * Returns the libSBML type code of this object instance.
   *
   * *
 * 
 * LibSBML attaches an identifying code to every kind of SBML object.  These
 * are integer constants known as <em>SBML type codes</em>.  The names of all
 * the codes begin with the characters <code>SBML_</code>.
 * @if clike The set of possible type codes for core elements is defined in
 * the enumeration #SBMLTypeCode_t, and in addition, libSBML plug-ins for
 * SBML Level&nbsp;3 packages define their own extra enumerations of type
 * codes (e.g., #SBMLLayoutTypeCode_t for the Level&nbsp;3 Layout
 * package).@endif@if java In the Java language interface for libSBML, the
 * type codes are defined as static integer constants in the interface class
 * {@link libsbmlConstants}.  @endif@if python In the Python language
 * interface for libSBML, the type codes are defined as static integer
 * constants in the interface class @link libsbml@endlink.@endif@if csharp In
 * the C# language interface for libSBML, the type codes are defined as
 * static integer constants in the interface class
 * @link libsbmlcs.libsbml@endlink.@endif  Note that different Level&nbsp;3
 * package plug-ins may use overlapping type codes; to identify the package
 * to which a given object belongs, call the <code>getPackageName()</code>
 * method on the object.
 *
 *
   *
   * @return the SBML type code for this object:
   * @link libsbml#SBML_DELAY SBML_DELAY@endlink (default).
   *
   * *
 * @warning <span class='warning'>The specific integer values of the possible
 * type codes may be reused by different Level&nbsp;3 package plug-ins.
 * Thus, to identifiy the correct code, <strong>it is necessary to invoke
 * both getTypeCode() and getPackageName()</strong>.</span>
 *
 *
   *
   * @see getElementName()
   * @see getPackageName()
   */ public new
 int getTypeCode() {
    int ret = libsbmlPINVOKE.Delay_getTypeCode(swigCPtr);
    return ret;
  }

  
/**
   * Returns the XML element name of this object, which for Delay, is
   * always @c 'delay'.
   * 
   * @return the name of this element, i.e., @c 'delay'.
   *
   * @see getTypeCode()
   */ public new
 string getElementName() {
    string ret = libsbmlPINVOKE.Delay_getElementName(swigCPtr);
    return ret;
  }

  
/**
   * Predicate returning @c true if
   * all the required elements for this Delay object
   * have been set.
   *
   * @note The required elements for a Delay object are:
   * @li 'math'
   *
   * @return a bool value indicating whether all the required
   * elements for this object have been defined.
   */ public new
 bool hasRequiredElements() {
    bool ret = libsbmlPINVOKE.Delay_hasRequiredElements(swigCPtr);
    return ret;
  }

  
/**
   * Finds this Delay's Event parent and calls unsetDelay() on it, indirectly
   * deleting itself.
   *
   * Overridden from the SBase function since the parent is not a ListOf.
   *
   * *
 * @return integer value indicating success/failure of the
 * function.  @if clike The value is drawn from the
 * enumeration #OperationReturnValues_t. @endif The possible values
 * returned by this function are:
 *
 *
   * @li @link libsbml#LIBSBML_OPERATION_SUCCESS LIBSBML_OPERATION_SUCCESS@endlink
   * @li @link libsbml#LIBSBML_OPERATION_FAILED LIBSBML_OPERATION_FAILED@endlink
   */ public new
 int removeFromParentAndDelete() {
    int ret = libsbmlPINVOKE.Delay_removeFromParentAndDelete(swigCPtr);
    return ret;
  }

  
/**
   * *
 * Replaces all uses of a given @c SIdRef type attribute value with another
 * value.
 *
 * *
 * 

 * In SBML, object identifiers are of a data type called <code>SId</code>.
 * In SBML Level&nbsp;3, an explicit data type called <code>SIdRef</code> was
 * introduced for attribute values that refer to <code>SId</code> values; in
 * previous Levels of SBML, this data type did not exist and attributes were
 * simply described to as 'referring to an identifier', but the effective
 * data type was the same as <code>SIdRef</code>in Level&nbsp;3.  These and
 * other methods of libSBML refer to the type <code>SIdRef</code> for all
 * Levels of SBML, even if the corresponding SBML specification did not
 * explicitly name the data type.
 *
 *
 *
 * This method works by looking at all attributes and (if appropriate)
 * mathematical formulas in MathML content, comparing the referenced
 * identifiers to the value of @p oldid.  If any matches are found, the
 * matching values are replaced with @p newid.  The method does @em not
 * descend into child elements.
 *
 * @param oldid the old identifier
 * @param newid the new identifier
 *
 *
   */ public new
 void renameSIdRefs(string oldid, string newid) {
    libsbmlPINVOKE.Delay_renameSIdRefs(swigCPtr, oldid, newid);
  }

  
/**
   * *
 * Replaces all uses of a given @c UnitSIdRef type attribute value with
 * another value.
 *
 * *
 * 
 * In SBML, unit definitions have identifiers of type <code>UnitSId</code>.  In
 * SBML Level&nbsp;3, an explicit data type called <code>UnitSIdRef</code> was
 * introduced for attribute values that refer to <code>UnitSId</code> values; in
 * previous Levels of SBML, this data type did not exist and attributes were
 * simply described to as 'referring to a unit identifier', but the effective
 * data type was the same as <code>UnitSIdRef</code> in Level&nbsp;3.  These and
 * other methods of libSBML refer to the type <code>UnitSIdRef</code> for all
 * Levels of SBML, even if the corresponding SBML specification did not
 * explicitly name the data type.
 *
 *
 *
 * This method works by looking at all unit identifier attribute values
 * (including, if appropriate, inside mathematical formulas), comparing the
 * referenced unit identifiers to the value of @p oldid.  If any matches
 * are found, the matching values are replaced with @p newid.  The method
 * does @em not descend into child elements.
 *
 * @param oldid the old identifier
 * @param newid the new identifier
 *
 *
   */ public new
 void renameUnitSIdRefs(string oldid, string newid) {
    libsbmlPINVOKE.Delay_renameUnitSIdRefs(swigCPtr, oldid, newid);
  }

  
/** */ /* libsbml-internal */ public new
 void replaceSIDWithFunction(string id, ASTNode function) {
    libsbmlPINVOKE.Delay_replaceSIDWithFunction(swigCPtr, id, ASTNode.getCPtr(function));
  }

}

}
