using System;
using System.Runtime.InteropServices;


/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 2.0.4
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

namespace libsbmlcs {

using System;
using System.Runtime.InteropServices;

public class SBMLNamespacesList : IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal SBMLNamespacesList(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(SBMLNamespacesList obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~SBMLNamespacesList() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          libsbmlPINVOKE.delete_SBMLNamespacesList(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

  public SBMLNamespacesList() : this(libsbmlPINVOKE.new_SBMLNamespacesList(), true) {
  }

  public void add(SBMLNamespaces item) {
    libsbmlPINVOKE.SBMLNamespacesList_add(swigCPtr, SBMLNamespaces.getCPtr(item));
  }

  public SBMLNamespaces get(uint n) {
    IntPtr cPtr = libsbmlPINVOKE.SBMLNamespacesList_get(swigCPtr, n);
    SBMLNamespaces ret = (cPtr == IntPtr.Zero) ? null : new SBMLNamespaces(cPtr, false);
    return ret;
  }

  public void prepend(SBMLNamespaces item) {
    libsbmlPINVOKE.SBMLNamespacesList_prepend(swigCPtr, SBMLNamespaces.getCPtr(item));
  }

  public SBMLNamespaces remove(uint n) {
    IntPtr cPtr = libsbmlPINVOKE.SBMLNamespacesList_remove(swigCPtr, n);
    SBMLNamespaces ret = (cPtr == IntPtr.Zero) ? null : new SBMLNamespaces(cPtr, false);
    return ret;
  }

  public uint getSize() {
    uint ret = libsbmlPINVOKE.SBMLNamespacesList_getSize(swigCPtr);
    return ret;
  }

}

}
