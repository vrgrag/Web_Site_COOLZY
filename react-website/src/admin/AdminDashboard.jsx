export default function AdminDashboard() {
  return (
    <div style={styles.container}>
      <h1 style={styles.title}>Добро пожаловать в панель управления 👋</h1>
      <p style={styles.subtitle}>
        Выберите нужный раздел в левом меню: товары, заказы, пользователи или отчёты.
      </p>
    </div>
  );
}

const styles = {
  container: {
    textAlign: "center",
    paddingTop: "100px",
    paddingLeft: "20px",
    paddingRight: "20px",
    fontFamily: "'Segoe UI', Tahoma, Geneva, Verdana, sans-serif",
  },
  title: {
    fontSize: "36px",
    fontWeight: "700",
    color: "#2c3e50",
    marginBottom: "20px",
  },
  subtitle: {
    fontSize: "18px",
    color: "#555",
    maxWidth: "600px",
    margin: "0 auto",
    lineHeight: "1.6",
  },
};
