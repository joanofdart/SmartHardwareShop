## Exciting Project
Web API developed in Core 5 with CRUD functionality and layer split.
There are two users: 
[*] admin/admin
[*] customer/customer

## API Testing
In order to get things going, all you have to do is build this solution and run either postman or
you can use the lovely swagger interface.

As requested, certain methods are protected from anonymous access, so please do add the required authorization
parameters.

I've opted to use LiteDB. You can find it in `SmartHardwareShop.API/shopDb.db` and the connectionString can be found inside
`appsettings.json`. You can delete the database if you'd like.

In order to test everything, please do know that you can either create one product at a time but for your sake and mine
I added a method called `Generate` which deals with creating some dummy values.

Steps:
[*] Generate products.
[*] Create a cart.
[*] Add or remove products from cart.
[*] Delete all products.
[*] Delete product.
[*] Close/open carts.
[*] Update cart.
[*] Update product.
[*] AuthTest: Authenticate using BasicAuthentication through `api/users/authenticate`
[*] AuthTest: Policy operations.

## Extra notes

Time taken: 5 hours. Mostly due to boilerplate code. 
Happiness level: 90. It was fun.
Final thoughts: I could create the next amazon just from this API *SurprisedPikachuFace*
Real final thoughts: I don't think that's possible :thinking: but thanks for the test, I'm exhausted.

## Conclusion

Some points are missing but I feel that I've taken too much time already and even tho I'd love to continue
(no problem in doing so), I'd also like to show what I did which its about 90% :)

