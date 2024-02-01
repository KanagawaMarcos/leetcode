//https://leetcode.com/problems/two-sum/
int* twoSum(int* nums, int numsSize, int target, int* returnSize) {
    int* result = malloc(2 * sizeof(int));
    if (result == NULL) {
        fprintf(stderr, "malloc failed\n");
        return NULL;
    }

    for (int i = 0; i < numsSize; i++) {
        for (int j = i + 1; j < numsSize; j++) {
            if (nums[i] + nums[j] == target) {
                result[0] = i;
                result[1] = j;
                *returnSize = 2;
                return result;
            }
        }
    }
    
    fprintf(stderr, "result not found\n");
    *returnSize = 0;
    return NULL;
}
