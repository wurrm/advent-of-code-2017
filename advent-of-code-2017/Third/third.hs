-- Wizards beware: this code sucks.

import System.Environment

incNextOdd :: Int -> Int
incNextOdd n
    | even n        = n + 1
    | otherwise     = n + 2

getRing :: Int -> Int
getRing max = (max - 1) `div` 2

getCentreDistance :: Int -> Int -> Int -> Int
getCentreDistance centre x increment
    | distance > increment = getCentreDistance (centre - increment) x increment
    | otherwise = distance
    where distance = abs (centre - x)

main = do
    args <- getArgs
    let x = read $ head args
    let ringMax = incNextOdd . floor $ sqrt $ fromIntegral x
    let r = getRing ringMax
    let c1 = ringMax ^ 2 - (ringMax - 1) `div` 2
    let a = getCentreDistance c1 x (r - 1)
    print (r + a)
