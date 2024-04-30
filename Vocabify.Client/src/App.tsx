import "./index.css";
import { AppProvider } from "./providers/AppProvider";
import { AppRouterProvider } from "./routes";

function App() {
  return (
    <AppProvider>
      <AppRouterProvider />
    </AppProvider>
  );
}

export default App;
