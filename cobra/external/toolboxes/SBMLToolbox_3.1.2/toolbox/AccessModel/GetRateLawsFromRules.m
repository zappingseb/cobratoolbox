function [Species, RateLaws] = GetRateLawsFromRules(SBMLModel)
% GetRateLawsFromRules takes an SBMLModel 
% and returns
%             1) an array of species names
%             2) an array of the character representation of the rate laws
%                   for each species from rules

%--------------------------------------------------------------------------
%
%  Filename    : GetRateLawsFromRules.m
%  Description : takes a SBMLModel and returns rate laws
%  Author(s)   : SBML Development Group <sbml-team@caltech.edu>
%  Organization: University of Hertfordshire STRC
%  Created     : 2004-11-12
%  Revision    : $Id: GetRateLawsFromRules.m 7155 2008-06-26 20:24:00Z mhucka $
%  Source      : $Source $
%
%<!---------------------------------------------------------------------------
% This file is part of SBMLToolbox.  Please visit http://sbml.org for more
% information about SBML, and the latest version of SBMLToolbox.
%
% Copyright 2005-2007 California Institute of Technology.
% Copyright 2002-2005 California Institute of Technology and
%                     Japan Science and Technology Corporation.
% 
% This library is free software; you can redistribute it and/or modify it
% under the terms of the GNU Lesser General Public License as published by
% the Free Software Foundation.  A copy of the license agreement is provided
% in the file named "LICENSE.txt" included with this software distribution.
% and also available online as http://sbml.org/software/sbmltoolbox/license.html
%----------------------------------------------------------------------- -->


% check input is an SBML model
if (~isSBML_Model(SBMLModel))
    error('GetRateLawsFromRules(SBMLModel)\n%s', 'input must be an SBMLModel structure');
end;

%--------------------------------------------------------------
            
% get information from the model
Species = GetSpecies(SBMLModel);
NumberSpecies = length(SBMLModel.species);
RateRules = Model_getListOfRateRules(SBMLModel);
NumRateRules = Model_getNumRateRules(SBMLModel);

% for each species loop through each reaction and determine whether the species
% takes part and in what capacity

for i = 1:NumberSpecies
    output = '';
 
    % if species is constant in level 2
    % concentration cannot be changed by a rate rule
    boundary = SBMLModel.species(i).boundaryCondition;
    if (SBMLModel.SBML_level == 2)
        constant = SBMLModel.species(i).constant;
    else
        constant = -1;
    end;
    
    if (constant == 1)
        output = '0';
    else
        
        %determine which rules it occurs within 
        j = 0;
        while (j <NumRateRules)
         
            if ((strcmp(Species(i), RateRules(j+1).variable)) | (strcmp(Species(i), RateRules(j+1).species)))
                output = RateRules(j+1).formula;
                break;
            else
                j = j + 1;
            end;
           
        end; % while NumRateRules
        
    end; % if constant
    
    
    % finished looking for this species
    % record rate law and loop to next species
    % rate = 0 if no law found
    if (isempty(output))
        RateLaws{i} = '0';
    else
        RateLaws{i} = output;
    end;
    
end; % for NumSpecies