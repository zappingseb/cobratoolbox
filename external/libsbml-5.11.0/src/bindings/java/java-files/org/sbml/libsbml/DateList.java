/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 2.0.4
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

package org.sbml.libsbml;

public class DateList {
  private long swigCPtr;
  protected boolean swigCMemOwn;

  public DateList(long cPtr, boolean cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = cPtr;
  }

  public static long getCPtr(DateList obj) {
    return (obj == null) ? 0 : obj.swigCPtr;
  }

  protected void finalize() {
    delete();
  }

  public synchronized void delete() {
    if (swigCPtr != 0) {
      if (swigCMemOwn) {
        swigCMemOwn = false;
        libsbmlJNI.delete_DateList(swigCPtr);
      }
      swigCPtr = 0;
    }
  }

  public DateList() {
    this(libsbmlJNI.new_DateList(), true);
  }

  public void add(Date item) {
    libsbmlJNI.DateList_add(swigCPtr, this, Date.getCPtr(item), item);
  }

  public Date get(long n) {
    long cPtr = libsbmlJNI.DateList_get(swigCPtr, this, n);
    return (cPtr == 0) ? null : new Date(cPtr, false);
  }

  public void prepend(Date item) {
    libsbmlJNI.DateList_prepend(swigCPtr, this, Date.getCPtr(item), item);
  }

  public Date remove(long n) {
    long cPtr = libsbmlJNI.DateList_remove(swigCPtr, this, n);
    return (cPtr == 0) ? null : new Date(cPtr, false);
  }

  public long getSize() {
    return libsbmlJNI.DateList_getSize(swigCPtr, this);
  }

}
