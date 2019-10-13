using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Domain
{

    public enum Status
    {
        PENDING,
        APPROVED
    };

    public enum ProductType
    {
        EXTRA,
        PRODUCT,
        PACKAGE
    }

    public enum MathVariable
    {
        k,
        c
    }

    public enum TrendTypes
    {
        PET,
        CHILDREN,
        COHABITANTS
    }
}
