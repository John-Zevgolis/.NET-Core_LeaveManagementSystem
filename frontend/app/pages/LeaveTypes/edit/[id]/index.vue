<template>
  <h1>Edit Leave Type</h1>
  <hr />
  <form v-if="leaveType" @submit.prevent="updateLeaveType">
    <div>
      <input type="text" v-model="form.name" />
      <p v-if="errors.Name">{{ errors.Name[0] }}</p>
    </div>
    <div>
      <input type="number" v-model="form.numberOfDays" />
      <p v-if="errors.NumberOfDays">{{ errors.NumberOfDays[0] }}</p>
    </div>
    <div>
      <button>Save</button>
      <NuxtLink to="/leavetypes">Back to List</NuxtLink>
    </div>
  </form>
</template>

<script setup>
const config = useRuntimeConfig();
const route = useRoute();

const form = reactive({
  id: Number(route.params.id),
  name: '',
  numberOfDays: 0,
});

const {
  data: leaveType,
  error,
  pending,
} = await useFetch(`${config.public.apiBase}/leavetypes/${route.params.id}`);

const errors = ref({});

const updateLeaveType = async () => {
  try {
    await $fetch(`${config.public.apiBase}/leavetypes/${route.params.id}`, {
      method: 'PUT',
      body: form,
    });
    await navigateTo('/leavetypes');
  } catch (error) {
    if (error.data && error.data.errors) {
      errors.value = error.data.errors;
    } else {
      console.error('Κάποιο άλλο άγνωστο σφάλμα:', error);
    }
  }
};

watch(
  leaveType,
  (value) => {
    ((form.id = route.params.id),
      (form.name = value.name),
      (form.numberOfDays = value.numberOfDays));
  },
  { immediate: true },
);
</script>

<style lang="scss" scoped></style>
