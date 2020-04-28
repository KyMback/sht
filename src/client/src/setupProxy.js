const { createProxyMiddleware } = require("http-proxy-middleware");

module.exports = function(app) {
    app.use("/api", createProxyMiddleware({ target: "http://localhost:5000", changeOrigin: false }));
    app.use("/graphql/playground", createProxyMiddleware({ target: "http://localhost:5000", changeOrigin: false }));
};
