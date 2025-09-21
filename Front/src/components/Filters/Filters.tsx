import styles from './Filters.module.css';

export const Filters = () => {
  return (
    <div className={styles.container}>
      <h3>Filters</h3>
      <div className={styles.filterGroup}>
        <label htmlFor="name">Name:</label>
        <input type="text" id="name" />
      </div>
      <div className={styles.filterGroup}>
        <label htmlFor="address">Address:</label>
        <input type="text" id="address" />
      </div>
      <div className={styles.filterGroup}>
        <label htmlFor="priceRange">Range price:</label>
        <input type="range" id="priceRange" />
      </div>

      <button>Apply</button>
    </div>
  )
}
