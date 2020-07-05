**Parking expert app**

_1. Add a car to the parking:_
    GET https://localhost:5001/api/parking/enter?carPlate=[carPlate]
    
_2. Exit from the parking:_
    GET https://localhost:5001/api/parking/exit?carPlate=[carPlate]
 
_3. Pay for the parking:_
    GET https://localhost:5001/api/payments/pay?carPlate=[carPlate]&amount=[amount]

_4. Get amount to pay:_
    GET https://localhost:5001/api/payments/amountToPay?carPlate=[carPlate]
    
_5. Get free spots:_
    GET https://localhost:5001/api/parking/freeSpots
    
_6. Generate report (month, quarter, year)_
    GET https://localhost:5001/api/reports/report?reportType=[reportType]

