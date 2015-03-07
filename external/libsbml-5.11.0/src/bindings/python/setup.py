## src/bindings/python/setup.py.  Generated from setup.py.in by configure.
##
## THIS FILE IS GENERATED BY CONFIGURE.  DO NOT EDIT SETUP.PY; EDIT SETUP.PY.IN
## INSTEAD.
##
## @file    setup.py.in
## @brief   Python distutils code for libSBML Python module
## @author  Michael Hucka
## @author  Ben Bornstein
## @author  Ben Kovitz
## 
## <!--------------------------------------------------------------------------
## This file is part of libSBML.  Please visit http://sbml.org for more
## information about SBML, and the latest version of libSBML.
##
## Copyright (C) 2013-2014 jointly by the following organizations:
##     1. California Institute of Technology, Pasadena, CA, USA
##     2. EMBL European Bioinformatics Institute (EMBL-EBI), Hinxton, UK
##     3. University of Heidelberg, Heidelberg, Germany
##
## Copyright (C) 2009-2013 jointly by the following organizations: 
##     1. California Institute of Technology, Pasadena, CA, USA
##     2. EMBL European Bioinformatics Institute (EMBL-EBI), Hinxton, UK
##  
## Copyright (C) 2006-2008 by the California Institute of Technology,
##     Pasadena, CA, USA 
##  
## Copyright (C) 2002-2005 jointly by the following organizations: 
##     1. California Institute of Technology, Pasadena, CA, USA
##     2. Japan Science and Technology Agency, Japan
## 
## This library is free software; you can redistribute it and/or modify it
## under the terms of the GNU Lesser General Public License as published by
## the Free Software Foundation.  A copy of the license agreement is provided
## in the file named "LICENSE.txt" included with this software distribution
## and also available online as http://sbml.org/software/libsbml/license.html
## ---------------------------------------------------------------------- -->*/

## Running setup.py currently needs 'make install'  or 'make create-build-dir' 
## to be run first. 'make install' or 'make create-build-dir' prepares the 
## package directory. (and copies libsbml.py into build/libsbml/__init__.py)

import os.path, sys
if not os.path.isfile('build/libsbml/__init__.py'):
      print("Please run 'make create-build-dir' prior to using this setup script.")
      sys.exit(1)

from distutils.core import setup, Extension



setup(name             = "libsbml", 
      version          = "5.11.0",
      description      = "LibSBML Python API",
      long_description = ("LibSBML is a library for reading, writing and "+
                          "manipulating the Systems Biology Markup Language "+
                          "(SBML).  It is written in ISO C and C++, supports "+
                          "SBML Levels 1, 2 and 3, and runs on Linux, Microsoft "+
                          "Windows, and Apple MacOS X.  For more information "+
                          "about SBML, please see http://sbml.org."),
      license          = "LGPL",
      author           = "SBML Team",
      author_email     = "libsbml-team@caltech.edu",
      url              = "http://sbml.org",
      packages         = ["libsbml"],
      package_dir      = {'libsbml': 'build/libsbml'},
      ext_package      = "libsbml",
      ext_modules      = [Extension("_libsbml", 
                                    ["libsbml.i"],
                                    swig_opts=['-c++', '-I../swig', '-I../../../include'], 
                                    include_dirs=["../../../include", ".", "../swig"])]
)
