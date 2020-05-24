module.exports = async function (context, req) {
  const principal = parseFloat(req.query.principal);
  const rate = parseFloat(req.query.rate);
  const term = parseFloat(req.query.term);

  if ([principal, rate, term].some(isNaN)) {
    context.res = {
      status: 400,
      body: 'Please supply principal, rate and term in the query string',
    };
  } else {
    let resp = { body: principal * rate * term };
    console.log('response: ', resp);
    context.res = resp;
  }
};
