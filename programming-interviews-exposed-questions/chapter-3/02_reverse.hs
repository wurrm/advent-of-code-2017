import System.Environment

-- NB since 'reverse' exists and isn't a library function we could just use that, but all the same

reverseString :: String -> String
reverseString [] = []
reverseString xs = last xs : (reverseString . init) xs

main = do args <- getArgs
          print . reverseString $ head args
