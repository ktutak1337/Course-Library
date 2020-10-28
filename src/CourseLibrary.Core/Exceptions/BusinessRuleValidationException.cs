using CourseLibrary.Core.BuildingBlocks;

namespace CourseLibrary.Core.Exceptions
{
    public class BusinessRuleValidationException : DomainException
    {
        public IBusinessRule BusinessRule { get; }
        public override string Code => BusinessRule.Code;

        public BusinessRuleValidationException(IBusinessRule businessRule)
            : base(businessRule.Message) 
                => BusinessRule = businessRule;
    }
}
