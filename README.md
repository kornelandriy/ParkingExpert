**Parking expert app v1.0**

_1. Add a car to the parking:_
    GET /api/parking/enter?carPlate=[carPlate]
    
_2. Exit from the parking:_
    GET /api/parking/exit?carPlate=[carPlate]
 
_3. Pay for the parking:_
    POST /api/payments/pay
    Content-Type: application/json
    
    {
        "CarPlate": [carPlate],
        "Amount": [amount]
    }

_4. Get amount to pay:_
    GET /api/payments/amountToPay?carPlate=[carPlate]
    
_5. Get free spots:_
    GET /api/parking/freeSpots
    
_6. Generate report (month, quarter, year)_
    GET /api/reports/generate?reportType=[reportType]

