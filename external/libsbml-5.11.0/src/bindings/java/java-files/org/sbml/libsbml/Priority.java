/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 2.0.4
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

package org.sbml.libsbml;

/** 
 *  The priority of execution of an SBML <em>event</em>.
 <p>
 * The {@link Priority} object class (which was introduced in SBML Level&nbsp;3
 * Version&nbsp;1), like {@link Delay}, is derived from {@link SBase} and contains a MathML
 * formula stored in the element 'math'.  This formula is used to compute a
 * dimensionless numerical value that influences the order in which a
 * simulator is to perform the assignments of two or more events that
 * happen to be executed simultaneously.  The formula may evaluate to any
 * <code>double</code> value (and thus may be a positive or negative number, or
 * zero), with positive numbers taken to signifying a higher priority than
 * zero or negative numbers.  If no {@link Priority} object is present on a given
 * {@link Event} object, no priority is defined for that event.
 <p>
 * <h2>The interpretation of priorities on events in a model</h2>
 <p>
 * For the purposes of SBML, <em>simultaneous event execution</em> is
 * defined as the situation in which multiple events have identical
 * times of execution.  The time of execution is calculated as the
 * sum of the time at which a given event's {@link Trigger} is <em>triggered</em>
 * plus its {@link Delay} duration, if any.  Here, <em>identical times</em> means
 * <em>mathematically equal</em> instants in time.  (In practice,
 * simulation software adhering to this specification may have to
 * rely on numerical equality instead of strict mathematical
 * equality; robust models will ensure that this difference will not
 * cause significant discrepancies from expected behavior.)
 <p>
 * If no {@link Priority} subobjects are defined for two or more {@link Event} objects,
 * then those events are still executed simultaneously but their order of
 * execution is <em>undefined by the SBML Level&nbsp;3 Version&nbsp;1
 * specification</em>.  A software implementation may choose to execute
 * such simultaneous events in any order, as long as each event is executed
 * only once and the requirements of checking the 'persistent' attribute
 * (and acting accordingly) are satisfied.
 <p>
 * If {@link Priority} subobjects are defined for two or more
 * simultaneously-triggered events, the order in which those particular
 * events must be executed is dictated by their {@link Priority} objects,
 * as follows.  If the values calculated using the two {@link Priority}
 * objects' 'math' expressions differ, then the event having
 * the higher priority value must be executed before the event with
 * the lower value.  If, instead, the two priority values are
 * mathematically equal, then the two events must be triggered in a
 * <em>random</em> order.  It is important to note that a <em>random
 *   order is not the same as an undefined order</em>: given multiple
 * runs of the same model with identical conditions, an undefined
 * ordering would permit a system to execute the events in (for
 * example) the same order every time (according to whatever scheme
 * may have been implemented by the system), whereas the explicit
 * requirement for random ordering means that the order of execution
 * in different simulation runs depends on random chance.  In other
 * words, given two events <em>A</em> and <em>B</em>, a randomly-determined
 * order must lead to an equal chance of executing <em>A</em> first or
 * <em>B</em> first, every time those two events are executed
 * simultaneously.
 <p>
 * A model may contain a mixture of events, some of which have
 * {@link Priority} subobjects and some do not.  Should a combination of
 * simultaneous events arise in which some events have priorities
 * defined and others do not, the set of events with defined
 * priorities must trigger in the order determined by their {@link Priority}
 * objects, and the set of events without {@link Priority} objects must be
 * executed in an <em>undefined</em> order with respect to each other
 * and with respect to the events with {@link Priority} subobjects.  (Note
 * that <em>undefined order</em> does not necessarily mean random
 * order, although a random ordering would be a valid implementation
 * of this requirement.)
 <p>
 * The following example may help further clarify these points.
 * Suppose a model contains four events that should be executed
 * simultaneously, with two of the events having {@link Priority} objects
 * with the same value and the other two events having {@link Priority}
 * objects with the same, but different, value.  The two events with
 * the higher priorities must be executed first, in a random order
 * with respect to each other, and the remaining two events must be
 * executed after them, again in a random order, for a total of four
 * possible and equally-likely event executions: A-B-C-D, A-B-D-C,
 * B-A-C-D, and B-A-D-C.  If, instead, the model contains four events
 * all having the same {@link Priority} values, there are 4! or 24
 * possible orderings, each of which must be equally likely to be
 * chosen.  Finally, if none of the four events has a {@link Priority}
 * subobject defined, or even if exactly one of the four events has a
 * defined {@link Priority}, there are again 24 possible orderings, but the
 * likelihood of choosing any particular ordering is undefined; the
 * simulator can choose between events as it wishes.  (The SBML
 * specification only defines the effects of priorities on {@link Event}
 * objects with respect to <em>other</em> {@link Event} objects with
 * priorities.  Putting a priority on a <em>single</em> {@link Event} object
 * in a model does not cause it to fall within that scope.)
 <p>
 * <h2>Evaluation of {@link Priority} expressions</h2>
 <p>
 * An event's {@link Priority} object 'math' expression must be
 * evaluated at the time the {@link Event} is to be <em>executed</em>.  During
 * a simulation, all simultaneous events have their {@link Priority} values
 * calculated, and the event with the highest priority is selected for
 * next execution.  Note that it is possible for the execution of one
 * {@link Event} object to cause the {@link Priority} value of another
 * simultaneously-executing {@link Event} object to change (as well as to
 * trigger other events, as already noted).  Thus, after executing
 * one event, and checking whether any other events in the model have
 * been triggered, all remaining simultaneous events that
 * <em>either</em> (i) have {@link Trigger} objects with attributes
 * 'persistent'=<code>false</code> <em>or</em> (ii) have {@link Trigger}
 * expressions that did not transition from <code>true</code> to
 * <code>false</code>, must have their {@link Priority} expression reevaluated.
 * The highest-priority remaining event must then be selected for 
 * execution next.
 <p>
 * <h2>Units of {@link Priority} object's mathematical expressions</h2>
 <p>
 * The unit associated with the value of a {@link Priority} object's
 * 'math' expression should be <code>dimensionless.</code>  This is
 * because the priority expression only serves to provide a relative
 * ordering between different events, and only has meaning with
 * respect to other {@link Priority} object expressions.  The value of
 * {@link Priority} objects is not comparable to any other kind of object in
 * an SBML model.
 <p>
 * @note The {@link Priority} construct exists only in SBML Level&nbsp;3; it cannot
 * be used in SBML Level&nbsp;2 or Level&nbsp;1 models.
 <p>
 * @see Event
 * @see Delay
 * @see EventAssignment
 */

public class Priority extends SBase {
   private long swigCPtr;

   protected Priority(long cPtr, boolean cMemoryOwn)
   {
     super(libsbmlJNI.Priority_SWIGUpcast(cPtr), cMemoryOwn);
     swigCPtr = cPtr;
   }

   protected static long getCPtr(Priority obj)
   {
     return (obj == null) ? 0 : obj.swigCPtr;
   }

   protected static long getCPtrAndDisown (Priority obj)
   {
     long ptr = 0;

     if (obj != null)
     {
       ptr             = obj.swigCPtr;
       obj.swigCMemOwn = false;
     }

     return ptr;
   }

  protected void finalize() {
    delete();
  }

  public synchronized void delete() {
    if (swigCPtr != 0) {
      if (swigCMemOwn) {
        swigCMemOwn = false;
        libsbmlJNI.delete_Priority(swigCPtr);
      }
      swigCPtr = 0;
    }
    super.delete();
  }

  
/**
   * Creates a new {@link Priority} object using the given SBML <code>level</code> and 
   * <code>version</code> values.
   <p>
   * @param level a long integer, the SBML Level to assign to this {@link Priority}
   <p>
   * @param version a long integer, the SBML Version to assign to this
   * {@link Priority}
   <p>
   * @throws SBMLConstructorException
   * Thrown if the given <code>level</code> and <code>version</code> combination, or this kind
   * of SBML object, are either invalid or mismatched with respect to the
   * parent {@link SBMLDocument} object.
   <p>
   * <p>
 * @note Attempting to add an object to an {@link SBMLDocument} having a different
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
 * {@link SBMLDocument}), knowledge of the intented SBML Level and Version help
 * libSBML determine such things as whether it is valid to assign a
 * particular value to an attribute.
   <p>
   * <p>
 * @note The {@link Priority} construct exists only in SBML Level&nbsp;3; it
 * cannot be used in SBML Level&nbsp;2 or Level&nbsp;1 models.
   */ public
 Priority(long level, long version) throws org.sbml.libsbml.SBMLConstructorException {
    this(libsbmlJNI.new_Priority__SWIG_0(level, version), true);
  }

  
/**
   * Creates a new {@link Priority} object using the given {@link SBMLNamespaces} object
   * <code>sbmlns</code>.
   <p>
   * <p>
 * The {@link SBMLNamespaces} object encapsulates SBML Level/Version/namespaces
 * information.  It is used to communicate the SBML Level, Version, and (in
 * Level&nbsp;3) packages used in addition to SBML Level&nbsp;3 Core.  A
 * common approach to using libSBML's {@link SBMLNamespaces} facilities is to create an
 * {@link SBMLNamespaces} object somewhere in a program once, then hand that object
 * as needed to object constructors that accept {@link SBMLNamespaces} as arguments. 
   <p>
   * @param sbmlns an {@link SBMLNamespaces} object.
   <p>
   * @throws SBMLConstructorException
   * Thrown if the given <code>level</code> and <code>version</code> combination, or this kind
   * of SBML object, are either invalid or mismatched with respect to the
   * parent {@link SBMLDocument} object.
   <p>
   * <p>
 * @note Attempting to add an object to an {@link SBMLDocument} having a different
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
 * {@link SBMLDocument}), knowledge of the intented SBML Level and Version help
 * libSBML determine such things as whether it is valid to assign a
 * particular value to an attribute.
   <p>
   * <p>
 * @note The {@link Priority} construct exists only in SBML Level&nbsp;3; it
 * cannot be used in SBML Level&nbsp;2 or Level&nbsp;1 models.
   */ public
 Priority(SBMLNamespaces sbmlns) throws org.sbml.libsbml.SBMLConstructorException {
    this(libsbmlJNI.new_Priority__SWIG_1(SBMLNamespaces.getCPtr(sbmlns), sbmlns), true);
  }

  
/**
   * Copy constructor; creates a copy of this {@link Priority}.
   <p>
   * @param orig the object to copy.
   <p>
   * @throws SBMLConstructorException
   * Thrown if the argument <code>orig</code> is <code>null.</code>
   */ public
 Priority(Priority orig) throws org.sbml.libsbml.SBMLConstructorException {
    this(libsbmlJNI.new_Priority__SWIG_2(Priority.getCPtr(orig), orig), true);
  }

  
/**
   * Creates and returns a deep copy of this {@link Priority} object.
   <p>
   * @return the (deep) copy of this {@link Priority} object.
   */ public
 Priority cloneObject() {
    long cPtr = libsbmlJNI.Priority_cloneObject(swigCPtr, this);
    return (cPtr == 0) ? null : new Priority(cPtr, true);
  }

  
/**
   * Get the mathematical formula for the priority and return it
   * as an AST.
   <p>
   * @return the math of this {@link Priority}.
   */ public
 ASTNode getMath() {
    long cPtr = libsbmlJNI.Priority_getMath(swigCPtr, this);
    return (cPtr == 0) ? null : new ASTNode(cPtr, false);
  }

  
/**
   * Predicate to test whether the formula for this delay is set.
   <p>
   * @return <code>true</code> if the formula (meaning the <code>math</code> subelement) of
   * this {@link Priority} is set, <code>false</code> otherwise.
   */ public
 boolean isSetMath() {
    return libsbmlJNI.Priority_isSetMath(swigCPtr, this);
  }

  
/**
   * Sets the math expression of this {@link Priority} instance to a copy of the given
   * {@link ASTNode}.
   <p>
   * @param math an {@link ASTNode} representing a formula tree.
   <p>
   * <p>
 * @return integer value indicating success/failure of the
 * function.   The possible values
 * returned by this function are:
   * <ul>
   * <li> {@link libsbmlConstants#LIBSBML_OPERATION_SUCCESS LIBSBML_OPERATION_SUCCESS}
   * <li> {@link libsbmlConstants#LIBSBML_INVALID_OBJECT LIBSBML_INVALID_OBJECT}
   * </ul>
   */ public
 int setMath(ASTNode math) {
    return libsbmlJNI.Priority_setMath(swigCPtr, this, ASTNode.getCPtr(math), math);
  }

  
/**
   * Returns the libSBML type code of this object instance.
   <p>
   * <p>
 * LibSBML attaches an identifying code to every kind of SBML object.  These
 * are integer constants known as <em>SBML type codes</em>.  The names of all
 * the codes begin with the characters <code>SBML_</code>.
 * In the Java language interface for libSBML, the
 * type codes are defined as static integer constants in the interface class
 * {@link libsbmlConstants}.    Note that different Level&nbsp;3
 * package plug-ins may use overlapping type codes; to identify the package
 * to which a given object belongs, call the <code>getPackageName()</code>
 * method on the object.
   <p>
   * @return the SBML type code for this object:
   * {@link libsbmlConstants#SBML_PRIORITY SBML_PRIORITY} (default).   <p>
   * <p>
 * @warning <span class='warning'>The specific integer values of the possible
 * type codes may be reused by different Level&nbsp;3 package plug-ins.
 * Thus, to identifiy the correct code, <strong>it is necessary to invoke
 * both getTypeCode() and getPackageName()</strong>.</span>
   <p>
   * @see #getElementName()
   * @see #getPackageName()
   */ public
 int getTypeCode() {
    return libsbmlJNI.Priority_getTypeCode(swigCPtr, this);
  }

  
/**
   * Returns the XML element name of this object, which for {@link Priority}, is
   * always <code>'priority'.</code>
   <p>
   * @return the name of this element, i.e., <code>'priority'.</code>
   <p>
   * @see #getTypeCode()
   */ public
 String getElementName() {
    return libsbmlJNI.Priority_getElementName(swigCPtr, this);
  }

  
/**
   * Predicate returning <code>true</code> if all the required elements for this
   * {@link Priority} object have been set.
   <p>
   * @note The required elements for a {@link Priority} object are:
   * <ul>
   * <li> 'math'
   *
   * </ul> <p>
   * @return a boolean value indicating whether all the required
   * elements for this object have been defined.
   */ public
 boolean hasRequiredElements() {
    return libsbmlJNI.Priority_hasRequiredElements(swigCPtr, this);
  }

  
/**
   * Finds this {@link Priority}'s {@link Event} parent and calls unsetPriority() on it,
   * indirectly deleting itself.
   <p>
   * Overridden from the {@link SBase} function since the parent is not a {@link ListOf}.
   <p>
   * <p>
 * @return integer value indicating success/failure of the
 * function.   The possible values
 * returned by this function are:
   * <ul>
   * <li> {@link libsbmlConstants#LIBSBML_OPERATION_SUCCESS LIBSBML_OPERATION_SUCCESS}
   * <li> {@link libsbmlConstants#LIBSBML_OPERATION_FAILED LIBSBML_OPERATION_FAILED}
   * </ul>
   */ public
 int removeFromParentAndDelete() {
    return libsbmlJNI.Priority_removeFromParentAndDelete(swigCPtr, this);
  }

  
/**
   * <p>
 * Replaces all uses of a given <code>SIdRef</code> type attribute value with another
 * value.
 <p>
 * <p>
 * In SBML, object identifiers are of a data type called <code>SId</code>.
 * In SBML Level&nbsp;3, an explicit data type called <code>SIdRef</code> was
 * introduced for attribute values that refer to <code>SId</code> values; in
 * previous Levels of SBML, this data type did not exist and attributes were
 * simply described to as 'referring to an identifier', but the effective
 * data type was the same as <code>SIdRef</code>in Level&nbsp;3.  These and
 * other methods of libSBML refer to the type <code>SIdRef</code> for all
 * Levels of SBML, even if the corresponding SBML specification did not
 * explicitly name the data type.
 <p>
 * This method works by looking at all attributes and (if appropriate)
 * mathematical formulas in MathML content, comparing the referenced
 * identifiers to the value of <code>oldid</code>.  If any matches are found, the
 * matching values are replaced with <code>newid</code>.  The method does <em>not</em>
 * descend into child elements.
 <p>
 * @param oldid the old identifier
 * @param newid the new identifier
   */ public
 void renameSIdRefs(String oldid, String newid) {
    libsbmlJNI.Priority_renameSIdRefs(swigCPtr, this, oldid, newid);
  }

  
/**
   * <p>
 * Replaces all uses of a given <code>UnitSIdRef</code> type attribute value with
 * another value.
 <p>
 * <p>
 * In SBML, unit definitions have identifiers of type <code>UnitSId</code>.  In
 * SBML Level&nbsp;3, an explicit data type called <code>UnitSIdRef</code> was
 * introduced for attribute values that refer to <code>UnitSId</code> values; in
 * previous Levels of SBML, this data type did not exist and attributes were
 * simply described to as 'referring to a unit identifier', but the effective
 * data type was the same as <code>UnitSIdRef</code> in Level&nbsp;3.  These and
 * other methods of libSBML refer to the type <code>UnitSIdRef</code> for all
 * Levels of SBML, even if the corresponding SBML specification did not
 * explicitly name the data type.
 <p>
 * This method works by looking at all unit identifier attribute values
 * (including, if appropriate, inside mathematical formulas), comparing the
 * referenced unit identifiers to the value of <code>oldid</code>.  If any matches
 * are found, the matching values are replaced with <code>newid</code>.  The method
 * does <em>not</em> descend into child elements.
 <p>
 * @param oldid the old identifier
 * @param newid the new identifier
   */ public
 void renameUnitSIdRefs(String oldid, String newid) {
    libsbmlJNI.Priority_renameUnitSIdRefs(swigCPtr, this, oldid, newid);
  }

  
/** * @internal */ public
 void replaceSIDWithFunction(String id, ASTNode function) {
    libsbmlJNI.Priority_replaceSIDWithFunction(swigCPtr, this, id, ASTNode.getCPtr(function), function);
  }

}
