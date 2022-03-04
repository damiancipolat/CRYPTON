const express = require('express');
const app = express();
const BlockIo = require('block_io');

//Envio una transaccion usando block.io
const sendTransaction=async (pin,key,from,to,amount)=>{

    const block_io = new BlockIo(key);

    //Prepar la transaccion.
    const prepared_transaction = await block_io.prepare_transaction({
      from_addresses: from,
      to_addresses:to,
      amount
    });

    //Hago la firma de la transaccion.
    const signed_transaction = await block_io.create_and_sign_transaction({
        data: prepared_transaction,
        pin
    });

    console.log('Signed transaction',signed_transaction);

    //Hago la transferencia.
    let result = await block_io.submit_transaction({
        transaction_data: signed_transaction
    });

    console.log('Sent result',result);

    return result;
}

app.get('/send-transaction/:pin/:key/:from/:to/:amount', async (req, res)=>{

    //Extraigo los valores.
    const {
        pin,
        key,
        from,
        to,
        amount
    } = req.params;

    console.log("Received",{...req.params});

    const result = await sendTransaction(pin,key,from,to,amount);

    res.json({
        block_io_transference:result
    });

})

app.listen(8080,()=>{
    console.log("block io - signer running in port 8080");
});

/*

// load this library
const BlockIo = require('block_io');

// instantiate a client
const block_io = new BlockIo('7ebe-8f45-4490-37d4');

async function example() {
  try {
    //print the account balance
    //let balance = await block_io.get_balance();
    //console.log(JSON.stringify(balance,null,2));

    // print first page of unarchived addresses on this account
    //let addresses = await block_io.get_my_addresses({address:'2MzZSEKfAUmGyoi2wsAB41qK2PzwjLoCYeD'});
    //console.log(JSON.stringify(addresses,null,2));

    // withdrawal:
    //   prepare_transaction ->
    //   summarize_prepared_transaction ->
    //   create_and_sign_transaction ->
    //   submit_transaction
    let prepared_transaction = await block_io.prepare_transaction({
      from_addresses: '2MzZSEKfAUmGyoi2wsAB41qK2PzwjLoCYeD',
      to_addresses:'2NGGLBSEvHrqGN5SULcxogbwjDYpkxhipPp',
      amount: '0.00001000'
    });
    
    // inspect the prepared data for yourself. here's a
    // summary of the transaction you will create and sign
    let summarized_transaction = await block_io.summarize_prepared_transaction({
        data: prepared_transaction
    });
    //console.log(JSON.stringify(summarized_transaction,null,2));
    
    // create and sign this transaction:
    // we specify the PIN here to decrypt
    // the private key to sign the transaction
    let signed_transaction = await block_io.create_and_sign_transaction({
        data: prepared_transaction,
        pin: '153629damian20403629'
    });
console.log(JSON.stringify(signed_transaction));
    // inspect the signed transaction yourself
    // once satisfied, submit it to Block.io
    let result = await block_io.submit_transaction({
        transaction_data: signed_transaction
    });
    console.log(JSON.stringify(result,null,2)); 

  } catch (error) {
    console.log("Error:", error.message);
  }
}

example();*/