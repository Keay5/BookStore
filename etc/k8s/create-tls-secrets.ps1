mkcert `
"bookstore-st-authserver" `
"bookstore-st-web" `
"bookstore-st-public-web" `
"bookstore-st-gateway-web" "bookstore-st-gateway-web-public" `
"bookstore-st-identity" "bookstore-st-administration" "bookstore-st-saas" "bookstore-st-product" 
kubectl create namespace bookstore
kubectl create secret tls -n bookstore bookstore-tls --cert=./bookstore-st-authserver+8.pem  --key=./bookstore-st-authserver+8-key.pem