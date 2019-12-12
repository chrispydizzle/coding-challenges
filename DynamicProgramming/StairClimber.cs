namespace CodeChallenges.DynamicProgramming
{
    public class StairClimber
    {
        public int ClimbStairs(int numberOfSteps)
        {
            if (numberOfSteps == 1)
            {
                return 1;
            }

            int[] currentStepSolutions = new int[numberOfSteps + 1];
            currentStepSolutions[1] = 1; // first step has only one way to get there
            currentStepSolutions[2] = 2; // second step has two ways
            
            // now we go to the third step, which will be the sum of the number of combinations we took to get to the previous two steps.
            for (int i = 3; i <= numberOfSteps; i++)
            {
                currentStepSolutions[i] = currentStepSolutions[i - 1] + currentStepSolutions[i - 2];
            }

            return currentStepSolutions[numberOfSteps];
        }
    }
}