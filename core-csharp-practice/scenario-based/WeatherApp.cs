using System;

class WeatherApp
{
    static Random rand = new Random();
    static int hoursInDay = 24;
    static int daysInMonth = 30;

    // --------------------------------------
    // Core data storage
    // --------------------------------------
    static double[] hourlyTemps = new double[daysInMonth * hoursInDay];
    static double[] dailyAverages = new double[daysInMonth];
    static double[] dailyMin = new double[daysInMonth];
    static double[] dailyMax = new double[daysInMonth];
    static double[] hourlyAverages = new double[hoursInDay];

    static double monthlyMin,
        monthlyMax,
        monthlyAverage;
    static int hottestDayIndex,
        coldestDayIndex;

    static void Main()
    {
        Console.WriteLine("\n===== WEATHER ANALYTICS CONSOLE APP =====\n");

        GenerateHourlyTemperatures();
        PrecomputeStats(); // Single pass for daily, monthly, hourly stats

        while (true)
        {
            PrintMenu();

            Console.WriteLine("\nSelect Category:");
            Console.WriteLine("1. General / Analytics");
            Console.WriteLine("2. Month-Specific");
            Console.WriteLine("3. Day-Specific");
            Console.WriteLine("4. Week-Specific");
            Console.WriteLine("5. Hour-Specific");
            Console.WriteLine("6. Exit\n");

            int category = GetUserInput("Enter category number: ", 1, 6);
            Console.WriteLine();

            if (category == 6)
            {
                Console.WriteLine("Thank you for using the Weather App.\n");
                return;
            }

            int option;

            switch (category)
            {
                // -------- GENERAL / ANALYTICS --------
                case 1:
                    option = GetUserInput("Enter option (1-5): ", 1, 5);
                    switch (option)
                    {
                        case 1:
                            DetectHeatwave();
                            break;
                        case 2:
                            DetectColdSpell();
                            break;
                        case 3:
                            PrintTemperatureTrend();
                            break;
                        case 4:
                            ForecastNextDay();
                            break;
                        case 5:
                            QuerySpecificTemperature();
                            break;
                    }
                    break;

                // -------- MONTH-SPECIFIC --------
                case 2:
                    option = GetUserInput("Enter option (1-5): ", 1, 5);
                    switch (option)
                    {
                        case 1:
                            PrintMonthlyMinMax();
                            break;
                        case 2:
                            PrintTemperatureRange();
                            break;
                        case 3:
                            PrintStandardDeviation();
                            break;
                        case 4:
                            PrintComfortIndex();
                            break;
                        case 5:
                            PrintMonthlySummary();
                            break;
                    }
                    break;

                // -------- DAY-SPECIFIC --------
                case 3:
                    option = GetUserInput("Enter option (1-4): ", 1, 4);
                    switch (option)
                    {
                        case 1:
                            QuerySpecificTemperature();
                            break;
                        case 2:
                            PrintDailyMinMax();
                            break;
                        case 3:
                            PrintHottestAndColdestDay();
                            break;
                        case 4:
                            PrintDailyAverageGraph();
                            break;
                    }
                    break;

                // -------- WEEK-SPECIFIC --------
                case 4:
                    option = GetUserInput("Enter option (1-3): ", 1, 3);
                    switch (option)
                    {
                        case 1:
                            PrintWeeklyMinMax();
                            break;
                        case 2:
                            CustomDateRangeAverage();
                            break;
                        case 3:
                            LastNDaysAverage();
                            break;
                    }
                    break;

                // -------- HOUR-SPECIFIC --------
                case 5:
                    option = GetUserInput("Enter option (1-2): ", 1, 2);
                    switch (option)
                    {
                        case 1:
                            HourlyAverageAcrossMonth();
                            break;
                        case 2:
                            ForecastNextHour();
                            break;
                    }
                    break;
            }

            Console.WriteLine("\n--------------------------------------------\n");
        }
    }

    // -----------------------------
    // GENERATE HOURLY TEMPERATURES
    // -----------------------------
    static void GenerateHourlyTemperatures()
    {
        for (int i = 0; i < hourlyTemps.Length; i++)
        {
            int hour = i % hoursInDay;
            hourlyTemps[i] = GenerateHourlyTemp(hour);
        }
    }

    // -----------------------------
    // REALISTIC HOURLY TEMPERATURE
    // -----------------------------
    static double GenerateHourlyTemp(int hour)
    {
        double min,
            max;
        if (hour < 6)
        {
            min = 10;
            max = 18;
        } // Night
        else if (hour < 9)
        {
            min = 15;
            max = 22;
        } // Early morning
        else if (hour < 12)
        {
            min = 20;
            max = 28;
        } // Morning
        else if (hour < 15)
        {
            min = 25;
            max = 35;
        } // Afternoon
        else if (hour < 18)
        {
            min = 24;
            max = 33;
        } // Evening
        else if (hour < 21)
        {
            min = 20;
            max = 28;
        } // Late evening
        else
        {
            min = 15;
            max = 22;
        } // Night
        return Math.Round(rand.NextDouble() * (max - min) + min, 2);
    }

    // -----------------------------
    // SINGLE-PASS PRECOMPUTE STATS
    // -----------------------------
    static void PrecomputeStats()
    {
        double[] hourlySum = new double[hoursInDay];
        monthlyMin = double.MaxValue;
        monthlyMax = double.MinValue;
        double sumDailyAvg = 0;

        hottestDayIndex = 0;
        coldestDayIndex = 0;

        for (int day = 0; day < daysInMonth; day++)
        {
            double dailySum = 0;
            double min = double.MaxValue;
            double max = double.MinValue;

            for (int h = 0; h < hoursInDay; h++)
            {
                double t = hourlyTemps[day * hoursInDay + h];
                dailySum += t;
                if (t < min)
                    min = t;
                if (t > max)
                    max = t;
                hourlySum[h] += t;
            }

            dailyAverages[day] = Math.Round(dailySum / hoursInDay, 2);
            dailyMin[day] = min;
            dailyMax[day] = max;

            sumDailyAvg += dailyAverages[day];

            if (dailyAverages[day] > dailyAverages[hottestDayIndex])
                hottestDayIndex = day;
            if (dailyAverages[day] < dailyAverages[coldestDayIndex])
                coldestDayIndex = day;

            if (min < monthlyMin)
                monthlyMin = min;
            if (max > monthlyMax)
                monthlyMax = max;
        }

        monthlyAverage = Math.Round(sumDailyAvg / daysInMonth, 2);

        for (int h = 0; h < hoursInDay; h++)
            hourlyAverages[h] = Math.Round(hourlySum[h] / daysInMonth, 2);
    }

    // -----------------------------
    // QUERY SPECIFIC TEMPERATURE
    // -----------------------------
    static void QuerySpecificTemperature()
    {
        Console.WriteLine("\n1. Specific Hour Temperature");
        Console.WriteLine("2. Specific Day Temperature");
        Console.WriteLine("3. Specific Week Temperature\n");

        int choice = GetUserInput("Choose option: ", 1, 3);

        if (choice == 1)
        {
            int day = GetUserInput("Day (1-30): ", 1, 30);
            int hour = GetUserInput("Hour (1-24): ", 1, 24);
            int index = (day - 1) * hoursInDay + (hour - 1);
            Console.WriteLine($"Temperature: {hourlyTemps[index]} °C");
        }
        else if (choice == 2)
        {
            int day = GetUserInput("Day (1-30): ", 1, 30);
            Console.WriteLine($"Average Temperature: {dailyAverages[day - 1]} °C");
        }
        else
        {
            int week = GetUserInput("Week (1-4): ", 1, 4);
            int start = (week - 1) * 7 * hoursInDay;
            int length = Math.Min(7 * hoursInDay, hourlyTemps.Length - start);
            double sum = 0;
            for (int i = start; i < start + length; i++)
                sum += hourlyTemps[i];
            Console.WriteLine($"Weekly Average: {Math.Round(sum / length, 2)} °C");
        }
    }

    // -----------------------------
    // FORECAST NEXT DAY
    // -----------------------------
    static void ForecastNextDay()
    {
        int userDay = GetUserInput("Enter Current Date (1-30): ", 1, daysInMonth);
        int userHour = GetUserInput("Enter Current Hour (1-24): ", 1, hoursInDay);

        int dayIndex = userDay - 1;
        int hourIndex = userHour - 1;

        int dayMinus2 = (dayIndex - 2 + daysInMonth) % daysInMonth;
        int dayMinus1 = (dayIndex - 1 + daysInMonth) % daysInMonth;

        double sum =
            hourlyTemps[dayMinus2 * hoursInDay + hourIndex]
            + hourlyTemps[dayMinus1 * hoursInDay + hourIndex];

        int count = 2;

        for (int h = 0; h <= hourIndex; h++)
        {
            sum += hourlyTemps[dayIndex * hoursInDay + h];
            count++;
        }

        double forecast = Math.Round(sum / count, 2);
        int forecastDay = (dayIndex + 1) % daysInMonth + 1;

        Console.WriteLine($"\nForecast for Day {forecastDay} at {userHour}:00 = {forecast} °C\n");
    }

    // -----------------------------
    // FORECAST NEXT HOUR
    // -----------------------------
    static void ForecastNextHour(int hoursWindow = 6)
    {
        int userDay = GetUserInput("Enter Current Date (1-30): ", 1, daysInMonth);
        int userHour = GetUserInput("Enter Current Hour (1-24): ", 1, hoursInDay);

        int dayIndex = userDay - 1;
        int hourIndex = userHour - 1;

        double sum = 0;
        int count = 0;

        for (int d = dayIndex - 2; d <= dayIndex; d++)
        {
            int actualDay = (d + daysInMonth) % daysInMonth;
            int startHour = Math.Max(0, hourIndex - hoursWindow + 1);
            int endHour = hourIndex;

            for (int h = startHour; h <= endHour; h++)
            {
                sum += hourlyTemps[actualDay * hoursInDay + h];
                count++;
            }
        }

        double forecast = Math.Round(sum / count, 2);
        int forecastDay = (dayIndex + (hourIndex + 1) / hoursInDay) % daysInMonth + 1;
        int forecastHour = (hourIndex + 1) % hoursInDay + 1;

        Console.WriteLine(
            $"\nForecast for Day {forecastDay} at {forecastHour}:00 = {forecast} °C\n"
        );
    }

    // -----------------------------
    // DAILY MIN/MAX
    // -----------------------------
    static void PrintDailyMinMax()
    {
        Console.WriteLine("DAY   MIN TEMP   MAX TEMP");
        for (int i = 0; i < daysInMonth; i++)
            Console.WriteLine($"{i + 1, -5} {dailyMin[i], -10} {dailyMax[i]}");
    }

    // -----------------------------
    // WEEKLY MIN/MAX
    // -----------------------------
    static void PrintWeeklyMinMax()
    {
        for (int week = 0; week < 4; week++)
        {
            int start = week * 7 * hoursInDay;
            int length = Math.Min(7 * hoursInDay, hourlyTemps.Length - start);
            double min = double.MaxValue,
                max = double.MinValue;
            for (int i = start; i < start + length; i++)
            {
                if (hourlyTemps[i] < min)
                    min = hourlyTemps[i];
                if (hourlyTemps[i] > max)
                    max = hourlyTemps[i];
            }
            Console.WriteLine($"Week {week + 1}: Min {min}, Max {max}");
        }
    }

    // -----------------------------
    // MONTHLY MIN/MAX
    // -----------------------------
    static void PrintMonthlyMinMax()
    {
        Console.WriteLine($"Monthly Min: {monthlyMin}, Max: {monthlyMax}");
    }

    // -----------------------------
    // HOTTEST AND COLDEST DAY
    // -----------------------------
    static void PrintHottestAndColdestDay()
    {
        Console.WriteLine($"Hottest Day: {hottestDayIndex + 1}");
        Console.WriteLine($"Coldest Day: {coldestDayIndex + 1}");
    }

    // -----------------------------
    // TEMPERATURE RANGE
    // -----------------------------
    static void PrintTemperatureRange()
    {
        Console.WriteLine($"Temperature Range: {monthlyMax - monthlyMin}");
    }

    // -----------------------------
    // STANDARD DEVIATION
    // -----------------------------
    static void PrintStandardDeviation()
    {
        double mean = monthlyAverage;
        double sumSq = 0;
        foreach (double t in hourlyTemps)
            sumSq += (t - mean) * (t - mean);
        Console.WriteLine($"Std Dev: {Math.Round(Math.Sqrt(sumSq / hourlyTemps.Length), 2)}");
    }

    // -----------------------------
    // HOURLY AVERAGE USING PRECOMPUTED DATA
    // -----------------------------
    static void HourlyAverageAcrossMonth()
    {
        int hour = GetUserInput("Hour (1-24): ", 1, 24);
        Console.WriteLine($"Hourly Average: {hourlyAverages[hour - 1]} °C");
    }

    // -----------------------------
    // CUSTOM DATE RANGE AVERAGE
    // -----------------------------
    static void CustomDateRangeAverage()
    {
        int startDay = GetUserInput("Start Day: ", 1, 30);
        int endDay = GetUserInput("End Day: ", startDay, 30);
        double sum = 0;
        int count = (endDay - startDay + 1) * hoursInDay;
        for (int i = (startDay - 1) * hoursInDay; i < endDay * hoursInDay; i++)
            sum += hourlyTemps[i];
        Console.WriteLine($"Average: {Math.Round(sum / count, 2)} °C");
    }

    // -----------------------------
    // LAST N DAYS AVERAGE
    // -----------------------------
    static void LastNDaysAverage()
    {
        int n = GetUserInput("Enter N days: ", 1, daysInMonth);
        double sum = 0;
        for (int i = daysInMonth - n; i < daysInMonth; i++)
            sum += dailyAverages[i];
        Console.WriteLine($"Average: {Math.Round(sum / n, 2)} °C");
    }

    // -----------------------------
    // HEATWAVE DETECTION
    // -----------------------------
    static void DetectHeatwave()
    {
        int count = 0;
        foreach (double t in hourlyTemps)
        {
            count = t > 35 ? count + 1 : 0;
            if (count >= 24)
            {
                Console.WriteLine("Heatwave detected.");
                return;
            }
        }
        Console.WriteLine("No heatwave detected.");
    }

    // -----------------------------
    // COLD SPELL DETECTION
    // -----------------------------
    static void DetectColdSpell()
    {
        int count = 0;
        foreach (double t in hourlyTemps)
        {
            count = t < 10 ? count + 1 : 0;
            if (count >= 24)
            {
                Console.WriteLine("Cold spell detected.");
                return;
            }
        }
        Console.WriteLine("No cold spell detected.");
    }

    // -----------------------------
    // COMFORT INDEX
    // -----------------------------
    static void PrintComfortIndex()
    {
        string status =
            monthlyAverage < 10 ? "Cold"
            : monthlyAverage < 25 ? "Pleasant"
            : monthlyAverage < 35 ? "Hot"
            : "Extreme";
        Console.WriteLine($"Comfort Index: {status}");
    }

    // -----------------------------
    // DAILY AVERAGE GRAPH
    // -----------------------------
    static void PrintDailyAverageGraph()
    {
        const double SCALE = 0.1;
        double minAvg = dailyAverages[0];
        for (int i = 1; i < daysInMonth; i++)
            if (dailyAverages[i] < minAvg)
                minAvg = dailyAverages[i];

        for (int day = 0; day < daysInMonth; day++)
        {
            int bars = (int)Math.Round((dailyAverages[day] - minAvg) / SCALE);
            Console.WriteLine(
                $"Day {day + 1, -2} | {new string('█', bars)} {dailyAverages[day]}°C"
            );
        }
    }

    // -----------------------------
    // TEMPERATURE TREND
    // -----------------------------
    static void PrintTemperatureTrend()
    {
        if (dailyAverages[1] > dailyAverages[0])
            Console.WriteLine("Temperature Trend: Rising");
        else if (dailyAverages[1] < dailyAverages[0])
            Console.WriteLine("Temperature Trend: Falling");
        else
            Console.WriteLine("Temperature Trend: Stable");
    }

    // -----------------------------
    // MONTHLY SUMMARY
    // -----------------------------
    static void PrintMonthlySummary()
    {
        Console.WriteLine($"Monthly Average: {monthlyAverage}");
        PrintHottestAndColdestDay();
    }

    // -----------------------------
    // USER INPUT VALIDATION
    // -----------------------------
    static int GetUserInput(string msg, int min, int max)
    {
        int val;
        while (true)
        {
            Console.Write(msg);
            string input = Console.ReadLine()?.Trim();
            if (int.TryParse(input, out val) && val >= min && val <= max)
                return val;
            Console.WriteLine("Invalid input. Try again.");
        }
    }

    // -----------------------------
    // PRINT MENU
    // -----------------------------
    static void PrintMenu()
    {
        Console.WriteLine(
            "=============================================================================================================="
        );
        Console.WriteLine(
            "                                      WEATHER ANALYTICS MENU                                                  "
        );
        Console.WriteLine(
            "==============================================================================================================\n"
        );

        // ---------------- ROW 1 ----------------
        Console.WriteLine(
            "               GENERAL / ANALYTICS            MONTH-SPECIFIC                DAY-SPECIFIC"
        );
        Console.WriteLine(
            "               ------------------            ----------------              ----------------"
        );
        Console.WriteLine(
            "               1. Heatwave Detection         1. Monthly Min & Max          1. Specific Day Average"
        );
        Console.WriteLine(
            "               2. Cold Spell Detection       2. Temperature Range          2. Daily Min & Max"
        );
        Console.WriteLine(
            "               3. Temperature Trend          3. Standard Deviation         3. Hottest & Coldest Day"
        );
        Console.WriteLine(
            "               4. Next Day Forecast          4. Comfort Index              4. Daily Average Graph"
        );
        Console.WriteLine("               5. Query Temperature          5. Monthly Summary");
        Console.WriteLine();

        // ---------------- ROW 2 ----------------
        Console.WriteLine(
            "               WEEK-SPECIFIC                  HOUR-SPECIFIC                 SYSTEM"
        );
        Console.WriteLine(
            "               ----------------              ----------------               ----------------"
        );
        Console.WriteLine(
            "               1. Weekly Min & Max           1. Hourly Average              1. Exit"
        );
        Console.WriteLine("               2. Custom Range Average       2. Next Hour Forecast");
        Console.WriteLine("               3. Last N Days Average");
        Console.WriteLine();

        Console.WriteLine(
            "--------------------------------------------------------------------------------------------------------------"
        );
    }
}
