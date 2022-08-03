# ParallelTesting
## Comparing parallel execution of tasks with serial execution

This is a simple Web API designed to illustrate the performance of different methods of processing a list of tasks.

## Running the test program

1. Clone the repository and build, then run the solution
2. In the Swagger UI, enter a number for the number of tasks to run for the **serial** endpoint
3. Output will look something like this: 

```
8/3/2022 7:26:38 PM :: Took 00:00:00.0000747 to create tasks.
8/3/2022 7:26:38 PM :: ***************** Starting Task Processing ************
8/3/2022 7:26:38 PM :: Start processing task 0
8/3/2022 7:26:40 PM :: Finished processing task 0 after 2290 ms
8/3/2022 7:26:40 PM :: Start processing task 1
8/3/2022 7:26:42 PM :: Finished processing task 1 after 1410 ms
8/3/2022 7:26:42 PM :: Start processing task 2
8/3/2022 7:26:43 PM :: Finished processing task 2 after 1110 ms
8/3/2022 7:26:43 PM :: Start processing task 3
8/3/2022 7:26:44 PM :: Finished processing task 3 after 1170 ms
8/3/2022 7:26:44 PM :: Start processing task 4
8/3/2022 7:26:45 PM :: Finished processing task 4 after 880 ms
8/3/2022 7:26:45 PM :: Total task processing time: 6 seconds
8/3/2022 7:26:45 PM :: Total stopwatch elapsed time: 00:00:06.9244209 seconds
```

4. Enter the same number of tasks to run for the **parallel** endpoint
5. Output will look like this:

```
8/3/2022 7:29:45 PM :: ***************** Starting Task Processing ************
8/3/2022 7:29:45 PM :: Start processing task 0
8/3/2022 7:29:45 PM :: Start processing task 1
8/3/2022 7:29:45 PM :: Start processing task 2
8/3/2022 7:29:45 PM :: Start processing task 3
8/3/2022 7:29:45 PM :: Start processing task 4
8/3/2022 7:29:46 PM :: Finished processing task 1 after 1240 ms
8/3/2022 7:29:48 PM :: Finished processing task 4 after 2370 ms
8/3/2022 7:29:48 PM :: Finished processing task 0 after 2530 ms
8/3/2022 7:29:49 PM :: Finished processing task 2 after 3610 ms
8/3/2022 7:29:49 PM :: Finished processing task 3 after 3890 ms
8/3/2022 7:29:49 PM :: Total task processing time: 13 seconds
8/3/2022 7:29:49 PM :: Total stopwatch elapsed time: 00:00:03.8992541 seconds
```
